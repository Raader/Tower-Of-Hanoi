namespace Tower_Of_Hanoi
{
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
