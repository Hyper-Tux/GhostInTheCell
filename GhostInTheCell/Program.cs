using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/

public abstract class Entity
{
    // Private member-variables
    // ------------------------

    // Unique identifier of the factory
    private uint _idEntity;
    //  player that owns the Entity : 1 for you, -1 for your opponent and 0 if neutral
    protected int _owner;
    //  number of cyborgs in the factory
    protected uint _numOfCyborgs;

    // Constructors
    // ------------

    public Entity(uint id)
    {
        this._idEntity = id;
    }

    public Entity(uint id, int owner, uint numOfCyborgs)
        : this(id)
    {
        this._owner = owner;
        this._numOfCyborgs = numOfCyborgs;
    }

    // Accessors
    // ---------
    public uint IdEntity        { get { return this._idEntity; } }
    public int Owner            { get { return this._owner; } }
    public uint NumOfCyborgs    { get { return this._numOfCyborgs; } }

    public bool IsMine          { get { return (this._owner == 1); } }
    public bool IsNeutral       { get { return (this._owner == 0); } }
    public bool IsAdverse       { get { return (this._owner == -1); } }

    public override bool Equals(Object obj)
    {
        Entity entityObj = obj as Entity;
        if (entityObj == null)
            return false;
        else
            return this._idEntity.Equals(entityObj._idEntity);
    }

    public override int GetHashCode()
    {
        return (int) this._idEntity;
    }
}

public class Factory : Entity
{
    // Private member-variables
    // ------------------------
    
    //  factory production (between 0 and 3)
    private uint _lvlProd;

    // Constructors
    // ------------

    public Factory(uint id)
        : base(id)
    { }

    // Accessors
    // ---------

    public uint LvlProd { get { return this._lvlProd; } }

    // Public methods
    // --------------

    public void addData(int owner, uint numOfCyborg, uint lvlProd)
    {
        base._owner = owner;
        base._numOfCyborgs = numOfCyborg;
        this._lvlProd = lvlProd;
    }
}

public class Troop : Entity
{
    // Private member-variables
    // ------------------------

    // arg2: identifier of the factory from where the troop leaves
    private Factory _firstFactory;
    // arg3: identifier of the factory targeted by the troop
    private Factory _secondFactory;
    // arg5: remaining number of turns before the troop arrives(positive integer)
    private uint _remainingTurns;

    private Link _attachedLink;

    // Constructors
    // ------------

    public Troop(uint id, int owner, Factory leavingFactory, Factory targetedFactory, uint numOfCyborgs, uint remainingTurns, Link attachedLink)
        : base (id, owner, numOfCyborgs)
    {
        this._firstFactory = leavingFactory;
        this._secondFactory = targetedFactory;
        this._remainingTurns = remainingTurns;
        this._attachedLink = attachedLink;
    }

    // Accessors
    // ---------

    public Factory FirstFactory     { get { return this._firstFactory; } }
    public Factory SecondFactory    { get { return this._secondFactory; } }
    public uint RemainingTurns      { get { return this._remainingTurns; } }
    public Link AttachedLink        { get { return this._attachedLink; } }
}

public class Link
{
    // Private member-variables
    // ------------------------
    private uint _timeTravel;
    private Factory _firstFactory;
    private Factory _secondFactory;
    private List<Troop> _listOfTroop;

    // Constructors
    // ------------

    public Link(uint timeTravel, Factory firstFactory, Factory secondFactory)
    {
        this._timeTravel = timeTravel;
        this._firstFactory = firstFactory;
        this._secondFactory = secondFactory;
    }

    // Accessors
    // ---------

    public uint TimeTravel          { get { return this._timeTravel; } }
    public Factory FirstFactory     { get { return this._firstFactory; } }
    public Factory SecondFactory    { get { return this._secondFactory; } }
    public List<Troop> ListOfTroop  { get { return this._listOfTroop; } }

    public void addTroop(uint idEntity, int owner, Factory firstFactory, Factory secondFactory, uint numOfCyborgs, uint remainingTurns)
    {
        this._listOfTroop.Add(new Troop(idEntity, owner, firstFactory, secondFactory, numOfCyborgs, remainingTurns, this));
    }

    public void clean()
    {
        this._listOfTroop.Clear();
    }
}

public class Graph
{
    // Private member-variables
    // ------------------------

    private uint _factoriesCount = 0;
    private Factory[] _factoriesArray;
    private Link[,] _links2DArray;
    
    // Constructors
    // ------------

    public Graph(int factoryNumber)
    {
        this._factoriesArray = new Factory[factoryNumber];
        this._links2DArray = new Link[factoryNumber, factoryNumber];
    }

    // Accessors
    // ---------

    public uint FactoriesCount          { get { return this._factoriesCount; } }
    public Factory[] FactoriesArray     { get { return this._factoriesArray; } }
    public Link[,] Links2DArray         { get { return this._links2DArray; } }

    public uint EntityIdOfBestFactoryToAttack
    {
        get {return 1; }
    }

    public uint MyNearestFactoryOf(uint EntityIdOfNotMineFactory) // But soon ...
    {
        return 1;
    }

    public uint AmountOfMyTroopsAttacking(uint EntityAFactoryNotMine)
    {
        return 1;
    }

    public void addLink(uint idEntityFirstFactory, uint idEntitySecondFactory, uint timeTravel)
    {
        int indiceFirstFactory = this.getFactoryIndice(idEntityFirstFactory);
        int indiceSecondFactory = this.getFactoryIndice(idEntitySecondFactory);

        if (indiceFirstFactory == -1)
        {
            indiceFirstFactory = (int) this._factoriesCount++;
            this._factoriesArray[indiceFirstFactory] = new Factory(idEntityFirstFactory);
        }

        if (indiceSecondFactory == -1)
        {
            indiceSecondFactory = (int) this._factoriesCount++;
            this._factoriesArray[indiceSecondFactory] = new Factory(idEntitySecondFactory);
        }

        this._links2DArray[indiceFirstFactory, indiceSecondFactory] = new Link(timeTravel, this._factoriesArray[indiceFirstFactory], this._factoriesArray[indiceSecondFactory]);
        this._links2DArray[indiceSecondFactory, indiceFirstFactory] = new Link(timeTravel, this._factoriesArray[indiceSecondFactory], this._factoriesArray[indiceFirstFactory]);
    }

    public void addDataToFactory(uint idFactory, int owner, uint numOfCyborg, uint lvlProd)
    {
        this._factoriesArray[this.getFactoryIndice(idFactory)].addData(owner, numOfCyborg, lvlProd);
    }

    public void addTroop(uint idEntity, int owner, uint firstFactory, uint secondFactory, uint numOfCyborgs, uint remainingTurns)
    {
        int indiceFirstFactory = this.getFactoryIndice(firstFactory);
        int indiceSecondFactory = this.getFactoryIndice(secondFactory);

        this._links2DArray[indiceFirstFactory, indiceSecondFactory].addTroop(idEntity, owner, this._factoriesArray[indiceFirstFactory], this._factoriesArray[indiceSecondFactory], numOfCyborgs, remainingTurns);
    }

    public void clean()
    {
        foreach (Link link in this._links2DArray)
            link.clean();
    }

    private int getFactoryIndice(uint idFactory)
    {
        uint cpt = 0;

        while (cpt < this._factoriesArray.Length)
        {
            if (this._factoriesArray[cpt].IdEntity == idFactory)
                return (int) cpt;
            cpt++;
        }

        return -1;
    }
}

class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        int factoryCount = int.Parse(Console.ReadLine()); // the number of factories
        Graph graph = new Graph(factoryCount);

        // Game Initialization
        // -------------------

        {
            int linkCount = int.Parse(Console.ReadLine()); // the number of links between factories
            for (int i = 0; i < linkCount; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                
                graph.addLink(uint.Parse(inputs[0]), uint.Parse(inputs[1]), uint.Parse(inputs[2]));
            }
        }

        // game loop
        while (true)
        {
            // Start Turn
            // ----------
            {
                int entityCount = int.Parse(Console.ReadLine()); // the number of entities (e.g. factories and troops)
                for (int i = 0; i < entityCount; i++)
                {
                    inputs = Console.ReadLine().Split(' ');

                    if (inputs[1] == "FACTORY")
                        graph.addDataToFactory(
                            uint.Parse(inputs[0]),  // Entity ID
                            int.Parse(inputs[2]),   // player that owns the factory: 1 for you, -1 for your opponent and 0 if neutral
                            uint.Parse(inputs[3]),  // number of cyborgs in the factory
                            uint.Parse(inputs[4])); // factory production (between 0 and 3)
                    else if (inputs[1] == "TROOP")
                        graph.addTroop(
                            uint.Parse(inputs[0]),  // Entity ID
                            int.Parse(inputs[2]),   // arg1: player that owns the troop: 1 for you or -1 for your opponent
                            uint.Parse(inputs[3]),  // arg2: identifier of the factory from where the troop leaves
                            uint.Parse(inputs[4]),  // arg3: identifier of the factory targeted by the troop
                            uint.Parse(inputs[5]),  // arg4: number of cyborgs in the troop(positive integer)
                            uint.Parse(inputs[6])); // arg5: remaining number of turns before the troop arrives(positive integer)
                }
            }

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            // Any valid action, such as "WAIT" or "MOVE source destination cyborgs"
            Console.WriteLine("WAIT");


            // End of the turn
            // ---------------
            graph.clean();
        }
    }
}