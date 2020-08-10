namespace SmartStore.DataAccess.Entity
{
    public class ProductPicture : BaseEntity
    {
        public int ProductID { get; set; }
        
        public int PictureID { get; set; }
        public  Picture Picture { get; set; }
    }
}
