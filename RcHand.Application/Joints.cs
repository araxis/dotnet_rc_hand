namespace RcHand.Application
{
    public struct Joint
    {
        public static readonly Joint Thumb = new(0);
        public static readonly Joint Index = new(1);
        public static readonly Joint Middle = new(2);
        public static readonly Joint Ring = new(3);
        public static readonly Joint Little = new(4);
        private Joint(int id)
        {
            Id = id;
        }
        public int Id { get; init; }
    }
}