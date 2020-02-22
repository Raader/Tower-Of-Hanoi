using System;
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
        public event Action BlockMoved;
        public event Action GameFinished;
        public List<MoveInfo> moves = new List<MoveInfo>();

        public class MoveInfo
        {

        }

        public HanoiGame(int blockCount)
        {
            this.blockCount = blockCount;
            SetupTowers();
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

        public void MoveBlock(int from, int to)
        {
            if (from > 3 || from < 0 || to > 3 || to < 0)
            {
                return; 
            }
            BlockMoved?.Invoke();
        }

        public void MoveBlock(Tower from, Tower to)
        {
            BlockMoved?.Invoke();
        }

        void CheckGame()
        {
            for (int i= 0; i < blockCount; i++)
            {
                if (towers[3][i] == null)
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
        
        public void AddBlockToTop(Block block)
        {
            for (int i = 0; i < blocks.Length; i++)
            {
                if (i + 1 < blocks.Length && blocks[i + 1] != null && blocks[i+1] > block)
                {
                    blocks[i] = block;
                    return;
                }
            }
            blocks[blocks.Length - 1] = block;
        }

        public void RemoveFromTop()
        {

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
