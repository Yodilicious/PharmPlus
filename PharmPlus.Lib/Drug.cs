namespace PharmPlus.Lib
{
    public class Drug
    {
        public Drug(string genericName, string brandName)
        {
            GenericName = genericName;
            BrandName = brandName;
        }

        public string GenericName { get; set; }
        public string BrandName { get; set; }
    }
}
