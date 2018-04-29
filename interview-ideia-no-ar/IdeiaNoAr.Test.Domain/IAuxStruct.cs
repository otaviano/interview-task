namespace IdeiaNoAr.Test.Domain
{
    public interface IAuxStruct
    {
        int Id { get; set; }
        string Label { get; set; }
        bool Primary { get; set; }
        string Value { get; set; }
    }
}