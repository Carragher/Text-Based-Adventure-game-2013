using System;
using System.Collections.Generic;
using System.IO;





class World
{
    List<Location> LocationList = new List<Location>();
    Dictionary<string, Item> Inventory = new Dictionary<string, Item>();
    int playerLocation;
    bool alive;
    // a constructor for the World Object.
    public World()
    {

        playerLocation = 0;
        alive = false;
    }
    // this method returns the alive bool to what called it.
    public bool TestLife()
    {


        return alive;
    }
    // this method sets the bool variable <alive> to true for the World that called it.
    public void MakeAlive()
    {
        alive = true;

    }
    // this method returns the players inventory.
    public Dictionary<string, Item> getInventory()
    {
        return Inventory;
    }
    // this method resets the players location to the start and resets his inventory.
    public void worldrester()
    {
        playerLocation = 0;
        Inventory = new Dictionary<string, Item>();


    }
    // this method returns the players location.
    public int playerlocator()
    {

        return playerLocation;


    }
    // this method removes an item from the players inventory.
    public void dropInventory(string name)
    {
        Inventory.Remove(name);

    }
    // this method adds an item to the players inventory.
    public void addInventory(string name, Item invItem)
    {
        Inventory.Add(name.ToLower(), invItem);

    }
    // this method is used to change the players location from one room to the next using a string variable. it returns a string variable.
    public string PlayerMover(string direction)
    {
        string result = "";
        

        int i = playerLocation;
        Location loc = LocationList[i];
        List<string> exits = loc.exitReturner();
        int[] locexits = loc.GetExits();
        int o = 0;
        if (direction == "north")
        {
            o = locexits[0];
            if (o != -1)
            {
                playerLocation = o;
                result = "you have been moved";
            }
            else
            {
                result = "there has been an error";
            }

        }
        if (direction == "south")
        {
            o = locexits[1];
            if (o != -1)
            {
                playerLocation = o;
                result = "you have been moved";
            }
            else
            {
                result = "there has been an error";
            }

        }
        if (direction == "east")
        {
            o = locexits[2];
            if (o != -1)
            {
                playerLocation = o;
                result = "you have been moved";
            }
            else
            {
                result = "there has been an error";
            }

        }
        if (direction == "west")
        {
            o = locexits[3];
            if (o != -1)
            {
                playerLocation = o;
                result = "you have been moved";
            }
            else
            {
                result = "there has been an error";
            }
        }
        if (direction == "up")
        {
            o = locexits[4];
            if (o != -1)
            {
                playerLocation = o;
                result = "you have been moved";
            }
            else
            {
                result = "there has been an error";
            }
        }
        if (direction == "down")
        {
            o = locexits[5];
            if (o != -1)
            {
                playerLocation = o;
                result = "you have been moved";
            }
            else
            {
                result = "there has been an error";
            }
        }
            
            

           
            
        



        return result;
    }
    // this method adds a location to the current world using a location variable provided.
    public  void AddLocation(Location location)
    {
        LocationList.Add(location);

    }
    // this method returns the current location of the player in a location variable.
    public Location GetCurrentLocation()
    {
        Location loc = new Location();
        int tester;
        int i = 0;
        if (LocationList.Count >= 1)
        {
            while (i > -1)
            {
                loc = LocationList[i];
                tester = loc.getRoomLocatior();
                if (playerLocation == tester)
                {
                    i = -2;

                }

                i++;
            }
        }

        


        return loc;
    }

    // this method takes a string that is the command, and a world which is the current playerworld. the method splits the command(if more than one word) determines which other methods to call depending
    // on the first word in the command string, and then sends the command string and the player world to other methods.
    //MUST USE GO WITH A DIRECTION OR SHIT BREAKS MAN
    public string Execute(string command, World world)
    {
        
        
        string result = "There must have been an error";
        string commandp1 = "";
        string commandp2 = "";
        if (command == "quit")
        {
            Console.WriteLine("Thanks for playing!");
            Environment.Exit(0);
        }
        List<string> commandSplit = new List<string>();
        string[] lineSplitter = command.Split(new char[] { ' ' });
        int o = -1;
        foreach (string s in lineSplitter)
        {
            o++;
            if (s != "")
            {
                commandSplit.Add(s);
            }
        }
        
        if (lineSplitter.Length > 2)
        {
            result = "there has been an error";
            return result;
        }
        if (lineSplitter.Length > 1)
        {
             commandp1 = commandSplit[0];
             commandp2 = commandSplit[1];
        }
        bool helper = false;
        if (command == "n" || command == "s" || command == "e" || command == "w" || command == "u" || command == "d")
        {
            commandp2 = command;
            helper = true;

        }
        if (commandp1 == "go" || helper == true)
        {
            if (commandp2 == "north" || commandp2 == "n")
            {
                result = PlayerMover("north");

            }

            if (commandp2 == "south" || commandp2 == "s")
            {
                result = PlayerMover("south");

            }

            if (commandp2 == "east" || commandp2 == "e")
            {
                result = PlayerMover("east");

            }

            if (commandp2 == "west" || commandp2 == "w")
            {
                result = PlayerMover("west");

            }

            if (commandp2 == "up" || commandp2 == "u")
            {
                result = PlayerMover("up");

            }

            if (commandp2 == "down" || commandp2 == "d")
            {
                result = PlayerMover("down");

            }

        }

        if (commandp1 == "take")
        {
            int i = playerLocation;
            Location loc = LocationList[i];
            result = loc.takeItem(commandp2, world);
        }

        if (commandp1 == "drop")
        {
            int i = playerLocation;
            Location loc = LocationList[i];

            int x = 0;
            bool test = true;
            Item finalItem = new Item();
            Item adder = new Item();
            bool failtest = false;
            string testmess = "";
            while (test == true)
            {
                Dictionary<string, Item> inventory = world.getInventory();
                if (inventory.ContainsKey(commandp2))
                {
                    adder = inventory[commandp2];
                    testmess = adder.namer();
                }

                
                
                

                if (testmess.ToLower() == commandp2)
                {
                    finalItem = adder;
                    test = false;

                }
                if (x > inventory.Count)
                {
                    test = false;
                    failtest = true;

                }

                x++;

            }
            if (failtest == false)
            {
                loc.addItem(finalItem);
                result = loc.dropItem(commandp2, world);
            }
            else
            {

                result = "The Item is not in your inventory";
            }
        }

        



        return result;


    }


    // fill in code here
}


class Location
{
    string desc;
    List<Item> Items = new List<Item>();
    int[] exits = new int[6];
    string image;
    int location;

    // constructor for a location object
    public Location()
    {

    }

    
    //constructor for a location object that takes an int, string, list<Item>, string, and int[].
    public Location(int locator, string description,List<Item> Locitems, string imageInit, int[] exit)
    {
        desc = description;
        Items = Locitems;
        exits = exit;
        image = imageInit;
        location = locator;
    }
    // this method adds an Item to the Item list in a location.
    public void addItem(Item item)
    {
        Items.Add(item);


    }

    // this method takes the Item from the location and sends it to be placed in the players inventory.
    public string takeItem(string name, World superworld)
    {

        string result = "The Item was not added to your inventory";

        int i = 0;
        bool test = false;
        bool firsttest = true;

        while (i < Items.Count)
        {
            Item testItem = Items[i];
            string nameStuff = testItem.namer();
            bool itemMovable = testItem.getMove();
            if (name == nameStuff && itemMovable == true)
            {
                 
                
                 superworld.addInventory(name, testItem);
                
                
                test = true;
            }
            if (test == true && firsttest == true)
            {
                Items.RemoveAt(i);
                result = "The Item has been added to your inventory!";
                firsttest = false;
            }
            i++;
        }
        return result;
    }

    // this method drops an Item from your inventory to the players current locaiton
    public string dropItem(string name, World world)
    {
        string result = "The Item was dropped from your inventory.";

       
         
        world.dropInventory(name);
       




        return result;
    }

    // this method returns the list of Items for a specific location.
    public List<Item> itemwriter()
    {

        return Items;


    }

    // this method returns the int value for a location.
    public int getRoomLocatior()
    {
        return location;
        
    }
    // this method returns the description of a location 
    public string GetDescription()
    {
        return desc; 

    }
    // this method returns the exits from a location
    public int[] GetExits()
    {

        return exits;
    }
    // this method returns a list<string> of what directions a player can go.
    public List<string> exitReturner()
    {
        List<string> batman = new List<string>();
        int i = 0;
        while (i != 6) {
            int test = 0;
            test = exits[i];



            if (test != -1 && i == 0)
            {
                batman.Add("North");
            }

            if (test != -1 && i == 1)
            {
                batman.Add("South");
            }

            if (test != -1 && i == 2)
            {
                batman.Add("East");
            }

            if (test != -1 && i == 3)
            {
                batman.Add("West");
            }

            if (test != -1 && i == 4)
            {
                batman.Add("Up");
            }

            if (test != -1 && i == 5)
            {
                batman.Add("Down");
            }

            i++;






        }
        return batman;
    }
    
}

class Item
{
    string name;
    string desc;
    bool moveable;
    int location;

    // constructor for the Item Object.
    public Item()
    {


    }
    // constructor for the Item object that takes a string, string, bool , and an int.
    public Item(string itemName, string description, bool move, int loc)
    {
        name = itemName;
        desc = description;
        moveable = move;
        location = loc;
    }
    //this method returns a bool var that tells wheter an item can move or not.
    public bool getMove()
    {
        return moveable;
    }

    // this method returns the name of an Item.
    public string namer()
    {
        return name;

    }

    
    // this method retuns the int loc of an item.
    public int getLoc()
    {
        return location;

    }

}

class IOLOGIC
{
    // this method loads a whole world from a txt file.
    public static World LoadWorld(string file){
        World BRAVENEWWORLD = new World();
        // debuging ?????
        try
        {
            using (StreamReader rd = new StreamReader(file)) // streamreader
            {

                string WORLDNAME = rd.ReadLine();
                int locationNumber = Convert.ToInt32(rd.ReadLine());
                int increment = 0;
                List<string> superList = new List<string>();
                List<string> itemList = new List<string>();
                //loads the locations I think????
                while (locationNumber != increment)
                {
                    string Line = rd.ReadLine();
                    bool test = true;
                    while (test == true)
                    {
                        superList.Add(Line);
                        test = false;
                    }
                    increment++;
                }
                string itemReader = "";
                // reads items into the list
                while (itemReader != null)
                {
                    itemReader = rd.ReadLine();
                    if (itemReader != null)
                    {
                        itemList.Add(itemReader);
                    }
                }
                List<Item> itemslocList = new List<Item>();
                int listLength = itemList.Count;
                int i = 0;


                // this while loop does strange things
                // mostly converting input to strings? not sure why its been a while
                // converts strings into an ITEM class its interesting 
                while (listLength > 0)
                {

                    string item = itemList[i];
                    string[] oneItem = new string[4];
                    string[] lineSplitter = item.Split(new char[] { '|' });
                    int o = -1;
                    foreach (string s in lineSplitter)
                    {
                        o++;
                        if (s != "")
                        {
                            oneItem[o] = s;
                        }
                    }
                    string itemName = oneItem[0];
                    string itemDesc = oneItem[1];
                    string itemMove = oneItem[2];
                    bool itemMover;
                    if (itemMove == "Y")
                    {
                        itemMover = true;
                    }
                    else
                    {
                        itemMover = false;
                    }
                    string blah = oneItem[3];
                    int itemLoc = Convert.ToInt32(oneItem[3]);
                    Item newItem = new Item(itemName, itemDesc, itemMover, itemLoc);
                    itemslocList.Add(newItem);
                    listLength--;
                    i++;
                }






                int locationtester = locationNumber;
                int supercounter = 0;
                string[] oneLocation = new string[4];
                //SO MUCH CONFUSION
                //but its ok
                //appears to make a list of locations and calls it super list
                //makes it a location
                //also adds it to the world.
                while (supercounter != locationtester)
                {
                    string Line = superList[supercounter];
                    string[] linesplitter = Line.Split(new char[] { '|' });
                    i = -1;
                    foreach (string s in linesplitter)
                    {
                        i++;
                        if (i != 4)
                        {
                            oneLocation[i] = s;
                        }
                    }
                    int location = Convert.ToInt32(oneLocation[0]);
                    string desc = oneLocation[1];
                    string image = oneLocation[2];
                    string exitMess = oneLocation[3];
                    int[] exitArray = new int[6];
                    string[] exitSplit = exitMess.Split(new char[] { ',' });
                    i = 0;
                    foreach (string x in exitSplit)
                    {

                        exitArray[i] = Convert.ToInt32(x.Trim());
                        i++;
                    }

                    int countList = itemslocList.Count;
                    int u = 0;
                    List<Item> FinalItemList = new List<Item>();
                    while (u != countList - 1)
                    {

                        Item mess = itemslocList[u];
                        int locator = mess.getLoc();
                        u++;
                        if (locator == location)
                        {
                            FinalItemList.Add(mess);
                        }
                    }
                    Location newloc = new Location(location, desc, FinalItemList, image, exitArray);
                    BRAVENEWWORLD.AddLocation(newloc);
                    supercounter++;
                }


                BRAVENEWWORLD.MakeAlive();
            }
        }
        catch
        {



        }
        return BRAVENEWWORLD;
        }



}

class Adventure
{

    static void Main()
    {




        Console.WriteLine("Welcome to my adventure!");


        World world = IOLOGIC.LoadWorld("myworld.txt");


        string command = "";
        while (command != "quit")
        {
            bool lifetest = world.TestLife();
            if (lifetest == true)
            {
                Location loc = world.GetCurrentLocation();
                Console.WriteLine("You are " + loc.GetDescription());
                bool itemwrite = true;
                int i = 0;
                Console.WriteLine("available items:");
                bool closer = false;
                while (itemwrite == true && closer == false)
                {

                    List<Item> itemStuff = loc.itemwriter();
                    string item = "";
                    int iftest = itemStuff.Count;
                    if (iftest != 0)
                    {
                        Item random = itemStuff[i];
                        item = random.namer();

                    }
                    else
                    {
                        closer = true;
                    }

                    int test = itemStuff.Count;

                    Console.WriteLine(item);
                    i++;

                    if (i == test)
                    {
                        itemwrite = false;
                    }



                }

                // display items present ...


                List<string> ironman = loc.exitReturner();
                int loop = ironman.Count;
                i = 0;

                while (i != loop)
                {
                    string exit = ironman[i];
                    Console.WriteLine("You can go " + exit);
                    i++;

                }


                // display available exits ...
                string result = "";
                Console.Write("Command: ");
                command = Console.ReadLine();
                command = command.ToLower().Trim();

                List<string> commandSplit = new List<string>();
                string[] lineSplitter = command.Split(new char[] { ' ' });
                int o = -1;
                foreach (string s in lineSplitter)
                {
                    o++;
                    if (s != "")
                    {
                        commandSplit.Add(s);
                    }
                }
                string commandp1 = "";
                string commandp2 = "";
                if (lineSplitter.Length > 1)
                {
                    commandp1 = commandSplit[0];
                    commandp2 = commandSplit[1];
                }

                if (commandp1 == "load")
                {
                    world = IOLOGIC.LoadWorld(commandp2);
                    world.worldrester();

                }
                else
                {
                    result = world.Execute(command, world);

                }
                Console.WriteLine(result);
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("The world you have tried to Load has failed. Now loading the base world....");
                world = IOLOGIC.LoadWorld("myworld.txt");


            }
        }
    }

}



