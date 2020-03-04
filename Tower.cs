namespace Tower_Of_Hanoi
{
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
}
