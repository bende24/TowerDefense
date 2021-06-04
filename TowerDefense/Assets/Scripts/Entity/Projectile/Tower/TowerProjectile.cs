public class TowerProjectile{
    protected ITowerTargetable target;
    protected Tower tower;

    public TowerProjectile(ITowerTargetable target, Tower tower)
    {
        this.target = target;
        this.tower = tower;

    }

    public virtual void hit(){
        
    }
}