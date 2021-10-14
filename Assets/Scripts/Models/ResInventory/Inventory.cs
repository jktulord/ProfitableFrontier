using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ResInventory
{
    public class Inventory
    {
        public Dictionary<ResKind, Resource> Res;
        public int Silver;

        public Inventory(bool IfHasLimit = false)
        {
            if (!IfHasLimit)
            {
                Res = new Dictionary<ResKind, Resource>();
                Res.Add(ResKind.Fish, new Resource(ResKind.Fish));
                Res.Add(ResKind.Wood, new Resource(ResKind.Wood));
                Res.Add(ResKind.Hides, new Resource(ResKind.Hides));
            }
            else
            {
                Res = new Dictionary<ResKind, Resource>();
                Res.Add(ResKind.Fish, new Resource(ResKind.Fish, limit: 0));
                Res.Add(ResKind.Wood, new Resource(ResKind.Wood, limit: 0));
                Res.Add(ResKind.Hides, new Resource(ResKind.Hides, limit: 0));
            }
            
            Silver = 0;
        }

        public static Inventory operator +(Inventory first, Inventory second)
        {
            Inventory inventory = new Inventory();
            foreach (ResKind kind in inventory.Res.Keys)
            {
                inventory.Res[kind].Limit = first.Res[kind].Limit;
                inventory.Res[kind].Amount = first.Res[kind].Amount + second.Res[kind].Amount;
            }
            inventory.Silver = first.Silver + second.Silver;
            return inventory;
        }

        public static Inventory operator +(Inventory first, Resource second)
        {
            first.Res[second.Name].Amount += second.Amount;
            return first;
        }

        public void Clear()
        {
            foreach (ResKind kind in Res.Keys)
            {
                Res[kind].Amount = 0;
            }
            Silver = 0;
        }

        public bool IfEmpty()
        {
            bool trigger = true;
            foreach (ResKind kind in Res.Keys)
            {
                if (Res[kind].Amount > 0)
                {
                    trigger = false;
                }
            }
            if (Silver > 0)
            {
                trigger = false;
            }
            return trigger;
        }
    }
}
