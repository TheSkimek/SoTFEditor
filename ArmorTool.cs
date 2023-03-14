using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoTFEditor
{
    public static class ArmorTool
    {
        public static JObject saveFileArmorObject;

        public static int[] armorSlots = new int[] { 0, 1, 4, 5, 6, 7, 8, 9, 10, 11 };        
    }

    enum armorTypes
    {
        LeafArmor = 473,
        BoneArmor = 494,
        DeerHideArmor = 519,
        TechArmor = 554,
        CreepyArmor = 593
    };
}
