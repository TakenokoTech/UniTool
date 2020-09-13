namespace Tests.PlayMode.ObjectEx
{
    public struct TestStructWithField
    {
        public string Key1;
        public string Key2;
        public string Key3;
    }
    
    public struct TestStructWithProperty
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }
    
    public struct TestStructWithFieldProperty
    {
        public string Key1;
        public string Property2 { get; set; }
    }
    
    public struct EmptyTestStruct
    {
    }
        
    public class TestClassWithField
    {
        public string Key1;
        public string Key2;
        public string Key3;
    }
    
    public struct TestClassWithProperty
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }
        
    public struct TestClassWithFieldProperty
    {
        public string Key1;
        public string Property2 { get; set; }
    }

    public class EmptyTestClass
    {
    }
}