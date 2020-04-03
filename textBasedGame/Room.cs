using System.Collections.Generic;

namespace textBasedGame
{
    public class Room
    {
        private string RoomTitle;
        public string GetTitle()
        {
            return RoomTitle;
        }

        private string RoomDescription;

        public string GetDescription()
        {
            return RoomDescription;
        }

        private List<Item> Inventory;

        public List<Item> GetInventory()
        {
            return new List<Item>(Inventory); 
        }
        private List<Door> Doors { get; }

        public List<Door> GetDoors()
        {
            return new List<Door>(Doors);
        }

        public Room()
        {
            RoomTitle = "";
            RoomDescription = "";
            Doors = new List<Door>();
            Inventory = new List<Item>();
        }

        public Room(string title)
        {
            RoomTitle = title;
            RoomDescription = "";
            Doors = new List<Door>();
            Inventory = new List<Item>();
        }

        public Room(string title, string description)
        {
            RoomTitle = title;
            RoomDescription = description;
            Doors = new List<Door>();
            Inventory = new List<Item>();
        }

        public override string ToString()
        {
            return RoomTitle.ToString();
        }

        public void AddDoor(Door door)
        {
            Doors.Add(door);
        }

        public void RemoveDoor(Door door)
        {
            if (Doors.Contains(door))
            {
                Doors.Remove(door);
            }
        }

        public void AddItem(Item itemToAdd)
        {
            Inventory.Add(itemToAdd);
        }

        public void RemoveItem(Item itemToRemove)
        {
            if (Inventory.Contains(itemToRemove))
            {
                Inventory.Remove(itemToRemove);
            }
        }

        public Item TakeItem(string name)
         {
             foreach (Item item in Inventory)
             {
                 if (item.Name.ToLower() == name)
                 {
                     Item temp = item;
                     Inventory.Remove(temp);
                     return temp;
                 }
             }
             return null;
         }
     }
 }