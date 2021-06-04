using System.Collections.Generic;

public interface ITowerPlatformObserver: IObserver {

    /// <summary>
    /// Gets called if player wants to build a tower
    /// </summary>
    /// <param name="signal"> The type of the tower </param>
    void onBuildNotify(TowerType signal);

    /// <summary>
    /// Gets called if player wants to upgrade the tower
    /// </summary>
    /// <param name="effect"></param>
    void onUpgradeNotify(Effect effect);
    
    /// <summary>
    /// Gets called if player wants to interact with the tower platform
    /// </summary>
    /// <param name="signal"></param>
    void onInteractNotify(Interaction signal);

    
    /// <summary>
    /// Gets called if player wants to destroy the tower
    /// </summary>
    void onTowerDestroyNotify();
}