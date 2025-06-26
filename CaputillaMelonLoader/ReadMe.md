# Caputilla MelonLoader
Caputilla MelonLoader is a Caputilla written from the ground up with MelonLoader in mind.

### For mod users:
1. Install the latest release of `CaputillaMelonLoader.dll`
2. Put it in your Mods folder
3. Enjoy!

### For mod creators:
1. Reference `CaputillaMelonLoader.dll` in your project
2. Do the following:
```C#
public class MainMod : MelonMod
{
    public override void OnInitializeMelon()
    {
        CaputillaMelonLoader.CaputillaHub.OnModdedJoin += OnJoinModded;
        CaputillaMelonLoader.CaputillaHub.OnModdedLeave += OnLeaveModded;
    }
    
    private void OnJoinModded()
    {
        // Code here runs when the user joins a modded room.
        // Use to initialize assets and other stuff.
    }
    
    private void OnLeaveModded()
    {
        // Code here runs when the user leaves a modded room.
        // Clean up after your mod so no things leak into normal lobbies.
    }
    
    public override void OnUpdate()
    {
        if (CaputillaMelonLoader.CaputillaHub.InModdedRoom)
        {
            // Code here runs every frame when the user is in a modded room.
        }
    }
}
```