//Events

//Events allow a class to notify interested observers that something has occurered, allowing them to respond to or handle the event: public event Action ThingHappened;
//Events use a delegate type to indicate what a handler must look like
//Raise events like this: ThingHappened();, or ThingHappened?.Invoke();
//Events can use any delegate type but should avoid non-void return types
//Other types can subscribe and unsubscribe to an event by providing a method: something.ThingHappened += Handler; and something.ThingHappened -= Handler;
//Don't forget to unsubscribe; objects that stay subscribed will not get garbage collected

//C# Events
//In C#, events are a mechanism that allows an object to notify others that something has changed or happened so they can respond. Suppose we were making a game of Asteroids. Let's say we have a Ship class, representing the concept of a ship, including if it is dead or alive, and a SoundEffectManager class, which has the responsibility to play sounds. We have an instance of each. When a ship blows up, an explosion sound effect should play. We have a few options for addressing this.

//If the Ship class knows about the SoundEffectManager class, it could call a method: _soundEffectManager.PlaySound("Explosion");. This design is not unreasonable. But if eight things need to respond to the ship exploding, it's less reasonable for Ship itself to reach out and call of of those different methods in response. As the number grows, the design looks worse and worse.

//Alternatively, we could ask each of those objects to implement some interface like this:
//public interface IExplosionHandler {
//  void HandleShipExploded();
//}

//SoundEffectManager could implement this interface and play the right sound. The other seven objects could do a similar thing. The Ship class can have a list of IExplosionHandler objects and call their HandleShipExploded method after the ship explodes. A slice of Ship might look like this:
//public class Ship {
//  private List<IExplosionHandler> _handlers = new List<IExplosionHandler>();
//  public void AddExplosionHandler(IExplosionHandler newHandler) => _handlers.Add(newHandler);
//  private void TellHandlersAboutExplosion()
//  {
//      foreach (IExplosionHandler handler in _handlers)
//          handler.HandleShipExploded();
//  }
//}

//Something within Ship would need to recognize that the ship has exploded and call TellHandlersAboutExplosion. The nice part of this setup is that the ship does not need to know all eight handler's unique aspects. Those objects sign up to be notified by calling AddExplosionHandler. C# provides a mechanism based on this approach that makes things very easy - events. Any class can create an event as a member, similar to making properties and methods. Any other objects interested in reacting to the event - a listener or an observer - can subscribe to the event to be notified when the event occurs. The class that owns the event can then raise or fire the event when the time is right, causing each listener's handler to run.

//Defining an event is shown below:
//public class Ship
//{
//  public event Action? ShipExploded;
//  //The rest of the ship's members are defined here
//}

//An event is defined using the event keyword, followed by a delegate type, then its name. Like every other member type, you can add an accessibility modifier to the event, as we did here with public. Events are typically public.

//In many ways, declaring an event is like an auto-property. Behind the scenes, a delegate object is created as a backing field for this event. In the case above, this delegate's type will be Action? (no parameters and a void return type, and with null allowed) since that is what the event's declaration named.

//When the Ship class detects the explosion, it will raise or fire this event, as shown below:
//public class Ship
//{
//  public event Action? ShipExploded;
//  public int Health { get; private set; }
//  public void TakeDamage(int amount)
//  {
//      Health -+ amount;
//      if (Health <= 0)
//          ShipExploded();
//  }
//}

//This notifies listeners that the event occurred, allowing them to run code in response. Alternatively, we can use the Invoke method:
//if (Health <= 0)
//  ShipExploded.Invoke();

//Let's look at the listener's side now. If we want SoundEffectManager to respond to the ship exploding, we define a method that matches the event's delegate type. In this case, that type is Action, which has a void return type and no parameters. This method can be called whatever we want, but names starting with On or Handle are both common:

//public class SoundEffectManager
//{
//  private void OnShipExploded() => PlaySound(("Explosion");
//  public void PlaySound(string name) { ... }
//}

//Next, we need to attach this method to the event. We could do this in the constructor:
//public SoundEffectManager(Ship ship)
//{
//  ship.ShipExploded += OnShipExploded;
//}

//This attaches or subscribes the OnShipExploded method to the event, ensuring it will be called when the event fires. When you are done, you can detach or unsubscribe the event like this:
//ship.ShipExploded -= OnShipExploded;

//The benefits of events are substantial. The object declaring the event does not have to know details about each object that responds to it. Each handler subscribes to the event with one of its methods, and everything else is taken care of automatically. Plus, unlike our interface approach, objects responding to the event do not need to implement any particular interface. They can call their event handler whatever makes sense for them.

//Events with Paramaters
//The code above used Action, which has no parameters. But events can supply data as arguments to their listeners by using a delegate type that includes parameters. For example, we could report the explosion's location with this:
//public class Ship
//{
//    public event Action<Point>? ShipExploded;
//    public int Health { get; private set; }
//    public Point Location { get; private set; } = new Point(0, 0);

//    public void TakeDamage(int amount)
//    {
//        Health -= amount;
//        if (Health <= 0)
//            ShipExploded(Location);
//    }
//}

//With this, an observer would subscribe using a method with a Point parameter. It can then use that parameter in deciding how to respond:
//public class SoundEffectManager
//{
//    private void OnShipExploded(Point location) =>
//                    PlaySound("Explosion", CalculateVolume(location));

//    public SoundEffectManager(Ship ship)
//    {
//        ship.ShipExploded += OnShipExploded;
//    }

//    public void PlaySound(string name, float volume) { ... }
//    private float CalculateVolume(Point location) { ... }
//}

//Null Events
//An event may be null if nothing has subscribed to it. Our eariler examples have ignored this possibility, which is dangerous. We should either check to see if the event is null or ensure that it isn't ever null by always giving it at least one event handler. The first option is more common and can be done by simply checking for null before raising the event:
//if (Health <= 0)
//  ShipExploded?.Invoke();

//The second option is tricky: ensure the event always has at least one handler. We rarely know of a valid handler when the object is created. That comes later. If we want to ensure that an event is never null, we'll need to add a dummy do-nothing handler. You could imagine making a private DoNothing method within the class, but that's not very elegant. The more common alternative is to use a lambda expression - the topic of Level 38. I'll show you that here, even though it won't make sense yet:
//public event Action ShipExploded = () => { };

//This initializer ensures ShipExploded will not be null, and we can change the event's type from Action? to Action. It comes with a cost: this empty method will run every time the event is raised.

//In my experience, more people will just allow the event to be null and then check for null when raising the event. But this second approach still comes up.

//Event Leaks
//As we saw in Level 14, the garbage collector is usually great at cleaning up heap objects when they are no longer usable. Any object that is referenced by another will stay alive. That has consequences for events. The delegate backing an event will hold a reference to any object subscribed to it. That means an object can survive even if the only thing hanging on to it is an event subscription. Usually, if something is meant to be alive, something besides an event will also have a reference to it. If an object is accidentally surviving because of an event subscription alone, it is called an event leak or an event memory leak.

//When an object is at the end of its life, it must unsubscribe from any events it is subscribed to, or it will not be garbage collected. (At least not until the object with the event dies as well.)

//There are lots of ways to approach this. One way - a rather poor way - is to ignore it. It only truly matters if you begin running out of memory or if all the excess event handling makes your program too slow. For tiny, short-lived programs, it may not present a big problem. It is safer to handle it, but sometimes the cost of getting it right is not worth the trouble.

//A common solution is to make a Cleanup method or pick your favourite name) that unsubscribes from any previously subscribed events. When it is time for the object to die, call the Cleanup method.

//A slight variation on that idea is to name that method Dispose and make your objects implement IDisposable. This is a topic covered in a bit more depth in Level 47. Several C# mechanisms will automatically call such a Dispose method, but you are still on the hook to call it yourself in other situations.

//EventHandler and Friends
//Using the various Action delegates with events in common, but another common choice is EventHandler(System namespace_, which is defined approximately like this:
//public delegate void EventHandler(object sender, EventArgs e);

//It has two arguments, sender is the source of the event. This parameter makes it easy for subscribers to hook up their handler to many source objects while still telling