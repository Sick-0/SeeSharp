using System;
using System.Collections.Generic;
using System.Data;

namespace textBasedGame
{
    public class Game
    {
        public bool IsRunning = true;
        private bool _gameOver = false;
        
        Room currentRoom;
        List<Item> inventory;

        public Game()
        {
            inventory = new List<Item>();
            
            Console.WriteLine("Welcome COVID-19 Survivor to the temple of DOOM");
            Console.WriteLine("If at any point you need help type 'h' or 'help'");
            
            // build the "map"
            Room room1 = new Room("Welcome Hall",
                "You enter a dark entrance hall decorated with toilet paper.\nThere are empty hand sanitizer bottles everywhere.");
            Item key = new Item("key", true, "A rusty old key, wonder what it's for.");
            room1.AddItem(key);

            Room room2 = new Room("Hidden Pathway",
                "You found a semi hidden pathway. At the end of it is no other door");
            Item safe = new Item("safe", false, "An old rusty safe. It reminds me of something long ago.");
            room2.AddItem(safe);
            
            Room room3 = new Room("Game Room",
                "A large room with a wooden desk,\non it is an RGB lit pc and empty bottles of mountain dew.");
            
            room1.AddDoor(new Door(Door.Directions.North, room2));
            room1.AddDoor(new Door(Door.Directions.East, room3));
            
            room2.AddDoor(new Door(Door.Directions.South, room1));
            
            room3.AddDoor(new Door(Door.Directions.West, room1));

            currentRoom = room1;
            ShowRoom();
        }

        public void ShowRoom()
        {
            Console.WriteLine("\n" + currentRoom.GetTitle() + "\n");
            Console.WriteLine(currentRoom.GetDescription());

            if (currentRoom.GetInventory().Count > 0)
            {
                Console.WriteLine("\nThe room contains the following:\n");

                for (int i = 0; i < currentRoom.GetInventory().Count; i++)
                {
                    Console.WriteLine(currentRoom.GetInventory()[i].Name);
                }
            }

            Console.WriteLine("\nAvailable doors: \n");

            foreach (Door door in currentRoom.GetDoors())
            {
                Console.WriteLine(door.GetDirections());
            }

            Console.WriteLine();
        }
        public void Update()
        {
            string currentthing = Console.ReadLine().ToLower();

            if (currentthing == "quit" || currentthing == "q")
            {
                IsRunning = false;
                return;
            }

            if (!_gameOver)
            {
                DoTheThing(currentthing);
            }
            else
            {
                Console.WriteLine("Farewell adventurer Type 'quit' or 'q'");
            }
        }
        
        public void DoTheThing(string thing)
        {
            if (thing == "help" || thing == "h")
            {
                Console.WriteLine("Welcome to this Adventure!");
                Console.WriteLine("'l' / 'look':        Shows you the room, its exits, and any items it contains.");
                Console.WriteLine("'Look at X':         Gives you information about a specific item in your \n                     inventory, where X is the items name.");
                Console.WriteLine("'pick up X':         Attempts to pick up an item, where X is the items name.");
                Console.WriteLine("'use X':             Attempts to use an item, where X is the items name.");
                Console.WriteLine("'i' / 'inventory':   Allows you to see the items in your inventory.");
                Console.WriteLine("'q' / 'quit':        Quits the game.");
                Console.WriteLine();
                Console.WriteLine("Directions can be input as either the full word, or the abbriviation, \ne.g. 'North or N'");
                return;
            }

            if (thing == "look" || thing == "l")
            {
                ShowRoom();
                if (currentRoom.GetInventory().Count==0)
                {
                    Console.WriteLine("There is nothing to do here.\n");
                }
                return;
            }
            
            //If statement for player to pick up objects
            //This works fine. Change how the function works later though.
            if (thing.Length >= 7 && thing.Substring(0, 7) == "pick up")
            {
                if (thing == "pick up")
                {
                    Console.WriteLine("\nPlease specify what you would like to pick up.\n");
                    return;
                }
                if (currentRoom.GetInventory().Exists(x => x.Name == thing.Substring(8)) && currentRoom.GetInventory().Exists(x => x.useAble == true))
                {
                    Item toAdd = currentRoom.TakeItem(thing.Substring(8));
                    inventory.Add(toAdd);
                    Console.WriteLine("\nYou pick up the " + thing.Substring(8) + ".\n");
                    return;
                }
                if (currentRoom.GetInventory().Exists(x => x.Name == thing.Substring(8)) && currentRoom.GetInventory().Exists(x => x.useAble == false))
                {
                    Console.WriteLine("\nYou cannot pick up the " + thing.Substring(8) + ".\n");
                    return;
                }
                else
                {
                    Console.WriteLine("\n" + thing.Substring(8) + " does not exist.\n");
                    return;
                }
            }
            
            if (thing.Length >= 7 && thing.Substring(0, 7) == "look at")
            {
                if (thing == "look at")
                {
                    Console.WriteLine("\nPlease specify what you wish to look at.\n");
                    return;
                }
                if (currentRoom.GetInventory().Exists(x => x.Name == thing.Substring(8)) || inventory.Exists(x => x.Name == thing.ToLower().Substring(8)))
                {
                    if (thing.Substring(8).ToLower() == "key")
                    {
                        Console.WriteLine("\n" + currentRoom.GetInventory().Find(x => x.Name.Contains("key")).description + "\n");
                        return;
                    }

                    if (thing.Substring(8).ToLower() == "safe")
                    {
                        Console.WriteLine("\n" + currentRoom.GetInventory().Find(x => x.Name.Contains("safe")).description + "\n");
                        return;
                    }

                    if (thing.Substring(8).ToLower() == "opened safe")
                    {
                        Console.WriteLine("\n" + currentRoom.GetInventory().Find(x => x.Name.Contains("opened safe")).description + "\n");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("\nThat item does not exist in this location or your inventory.\n");
                    return;
                }
            }

            if (thing.Length >= 3 && thing.Substring(0, 3) == "use")
            {
                if (thing == "use")
                {
                    Console.WriteLine("\nPlease specify what you wish to use.\n");
                    return;
                }
                if (inventory.Exists(x => x.Name == thing.ToLower().Substring(4)))
                {
                    Console.WriteLine("\nUse " + thing.Substring(4) + " with?\n");
                    string secondItem = Console.ReadLine();
                    if(currentRoom.GetInventory().Exists(x => x.Name == secondItem))
                    {
                        if(secondItem == "safe" && thing.Substring(4) == "key")
                        {
                            Item opendSafe = new Item("opened safe", false, "A safe with an cozy entrance. Filled with pillows and blankets");
                            currentRoom.AddItem(opendSafe);
                            foreach (Item item in currentRoom.GetInventory())
                            {
                                if (item.Name.ToLower() == "safe")
                                {
                                    currentRoom.RemoveItem(item);
                                    break;
                                }

                                if (item.Name.ToLower() == "key")
                                {
                                    currentRoom.RemoveItem(item);
                                    break;
                                }

                            }
                            Console.WriteLine("\nYou opend the safe\n");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Cannot do the thing.");
                        return;
                    }
                }
                if (currentRoom.GetInventory().Exists(x => x.Name == thing.ToLower().Substring(4)))
                {
                    if (thing.ToLower().Substring(4) == "safe")
                    {
                        Console.WriteLine("\nThe safe is locked tight, with no way of opening it.\n");
                        return;
                    }
                    if (thing.ToLower().Substring(4) == "opened safe")
                    {
                        Console.WriteLine("\nYou clamber in the safe. You are safe!");
                        _gameOver = true;
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("\nThere is nothing to use.\n");
                    return;
                }
            }

            if (MoveRoom(thing))
                return;

            Console.WriteLine("\nInvalid thing, are you confused?\n");
        }

        private bool MoveRoom(string whereTo)
        {
            foreach (Door door in currentRoom.GetDoors())
            {
                if (whereTo == door.ToString().ToLower() || whereTo == door.GetShortDirection().ToLower())
                {
                    currentRoom = door.GetLeadsTo();
                    Console.WriteLine("\nYou move " + door.ToString() + " to the:\n");
                    ShowRoom();
                    return true;
                }
            }

            return false;
        }
        
    }
}