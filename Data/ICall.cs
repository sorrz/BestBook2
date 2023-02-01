namespace BestBook2.Data
{
    public interface ICall
    {
        void Test(long isbn_value, long fromStore, long toStore, int stockChange);
    }
}
