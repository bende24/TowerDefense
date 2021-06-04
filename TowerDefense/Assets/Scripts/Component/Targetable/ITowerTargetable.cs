public interface ITowerTargetable : ITargetable {
    void recieveDamage(TowerSystem source, int damage);
    void giveReward(TowerSystem tower);
}