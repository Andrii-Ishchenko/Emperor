namespace Emperor.Core
{
    public interface IBuilding
    {
        int Count { get; }
        string Name { get; }
        int Price { get; }

        bool Build(int count);
        bool CanBeBuiltQuantity(int quantity);
        void Produce(YearlyBalance income);
    }
}