namespace WebApiFlorence
{
    public class Package
    {
        public int PackageId { get; set; }
        public string NamePackage { get ; set; }
        public double PricePackage { get; set; }
        public string Description { get; set; }
        public byte[]?  PackagePictureData { get; set; }
    }
}
