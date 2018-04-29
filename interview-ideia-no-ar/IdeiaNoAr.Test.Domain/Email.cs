namespace IdeiaNoAr.Test.Domain
{
    public class Email : IAuxStruct
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public string Value { get; set; }

        public bool Primary { get; set; }
    }
}