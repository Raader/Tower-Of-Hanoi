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
}
