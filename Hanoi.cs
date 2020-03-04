﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Of_Hanoi
{
    public class HanoiGame
    {
        public Tower[] towers = new Tower[3];
        public int blockCount;
        public delegate void MoveEvent(MoveInfo info);
        public MoveEvent BlockMoved;
        public event Action GameFinished;
        public List<MoveInfo> moves = new List<MoveInfo>();
        public MoveInfo originTowers;

        public class MoveInfo
        {
            public Tower[] towers;

            public MoveInfo(Tower[] towers)
            {
                this.towers = towers;
            }
        }

        public HanoiGame(int blockCount)
        {
            this.blockCount = blockCount;
            SetupTowers();
            Tower[] curTowers = new Tower[3];
            for (int i = 0; i < 3; i++)
            {
                curTowers[i] = new Tower(blockCount);
                curTowers[i].SetBlocks(towers[i].GetBlocks());
            }
            originTowers = new MoveInfo(curTowers);
            moves.Add(originTowers);
        }

        void SetupTowers()
        {
            for (int i = 0; i < towers.Length; i++)
            {
                towers[i] = new Tower(blockCount);
            }
            for (int i = blockCount ; i > 0; i--)
            {
                towers[0].AddBlockToTop(new Block(i));
            }
        }

        public void MoveBlock(Tower from, Tower to)
        {
            Block block = from.TopBlock;
            if(block == null || !to.AddBlockToTop(block))
            {
                return;
            }
            from.TopBlock = null;
            Tower[] curTowers = new Tower[3];
            for (int i = 0; i < 3; i++)
            {
                curTowers[i] = new Tower(blockCount);
                curTowers[i].SetBlocks(towers[i].GetBlocks());
            }
            MoveInfo moveInfo = new MoveInfo(curTowers);
            moves.Add(moveInfo);
            BlockMoved?.Invoke(moveInfo);
            CheckGame();
        }

        void CheckGame()
        {
            for (int i= 0; i < blockCount; i++)
            {
                if (towers[2][i] == null)
                {
                    return;
                }
            }
            GameFinished?.Invoke();
        }

    }

    public class Tower
    {
        Block[] blocks;
        public int blockCount;
        public Block TopBlock
        {
            get
            {
                for (int i = 0;i < blocks.Length; i++)
                {
                    if (blocks[i] != null)
                    {
                        return blocks[i];   
                    }
                }
                return null;
            }
            set
            {
                for (int i = 0; i < blocks.Length; i++)
                {
                    if (blocks[i] != null)
                    {
                        blocks[i] = value;
                        return;
                    }
                }
            }
        }

        public Tower(int size)
        {
            blocks = new Block[size];
            blockCount = size;          
        }

        public Block GetTopBlock()
        {
            return null;
        }
        
        public bool AddBlockToTop(Block block)
        {
            for (int i = 0; i < blocks.Length; i++)
            {
                if (i + 1 < blocks.Length && blocks[i + 1] != null && blocks[i+1] > block)
                {
                    blocks[i] = block;
                    return true;
                }
                else if(i + 1 < blocks.Length && blocks[i + 1] != null && blocks[i + 1] < block)
                {
                    return false;
                }
            }
            blocks[blocks.Length - 1] = block;
            return true;

        }

        public void SetBlocks(Block[] blocks)
        {
            if(blocks.Length != this.blocks.Length)
            {
                return;
            }
            this.blocks = blocks;
        }
        public Block[] GetBlocks()
        {
            return blocks.Clone() as Block[];
        }
        public Block this[int index]
        {
            get
            {
                if (index >= 0 && index < blocks.Length)
                {
                    return blocks[index];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (index >= 0 && index < blocks.Length)
                {
                    blocks[index] = value;
                }
            }

        }

        public Tower GetCopy()
        {
            return this.MemberwiseClone() as Tower;
        }

    }

    public class Block
    {
        public int size;

        public Block(int size)
        {
            this.size = size;
        }

        public static bool operator >(Block a,Block b)
        {
            return a.size > b.size;
        }

        public static bool operator <(Block a, Block b)
        {
            return a.size < b.size;
        }
    }
}
