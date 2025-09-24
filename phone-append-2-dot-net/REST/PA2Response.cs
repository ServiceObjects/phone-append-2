using System.Runtime.Serialization;

[DataContract]
public class PA2Response
{
    public PhoneInfo PhoneInfo { get; set; }
    public Error Error { get; set; }

    public override string ToString()
    {
        return $"PA2 PhoneInfo: {PhoneInfo} \nError: {Error}\n";
    }

}
public class PhoneInfo
{
    public string Phone { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string IsResidential { get; set; }
    public string Certainty { get; set; }
    public string LineType { get; set; }
    public override string ToString()
    {
        return $"Phone: {Phone}\n" +
               $"Name: {Name}\n" +
               $"Address: {Address}\n" +
               $"City: {City}\n" +
               $"State: {State}\n" +
               $"Postal Code: {PostalCode}\n" +
               $"Is Residential: {IsResidential}\n" +
               $"Certainty: {Certainty}\n" +
               $"Line Type: {LineType}\n";
    }
}
public class Error
{
    public string Type { get; set; }
    public string TypeCode { get; set; }
    public string Desc { get; set; }
    public string DescCode { get; set; }
    public override string ToString()
    {
        return $"Type: {Type} " +
            $"TypeCode: {TypeCode} " +
            $"Desc: {Desc} " +
            $"DescCode: {DescCode} ";
    }
}

