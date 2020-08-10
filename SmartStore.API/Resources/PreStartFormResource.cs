using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartStore.API.Resources
{
    public class PreStartFormResource
    {
        public List<CheckList> CheckList { get; set; }
        public bool FinalConfirmation { get; set; }
        public PlantDetails PlantDetails { get; set; }
    }

    public class Item
    {
        public string item { get; set; }
        public bool Selected { get; set; }
    }

    public class CheckList
    {
        public bool Expended { get; set; }
        public List<Item> Items { get; set; }
        public string Type { get; set; }
    }

    public class PlantDetails
    {
        public string OperationKM { get; set; }
        public string PlantNo { get; set; }
        public string ProjectName { get; set; }
    }
}
