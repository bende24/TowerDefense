public class Enemy: Entity{
    public EnemyType type;
    public float movespeed;
    public int damage;
    public int moneyDrop;
    public int expDrop;
    public int health;
    public bool isDead;
    public float spawntime;
    public static int ids = 0;

    public Enemy(EnemyData enemyData) {
        type = enemyData.type;
        this.id = ids++;
        movespeed = enemyData.movementSpeed;
        moneyDrop = enemyData.moneyValue;
        expDrop = enemyData.xpValue;
        damage = enemyData.damage;
        health = enemyData.health;
        isDead = false;
        spawntime = enemyData.spawntime;
    }
    
    public Enemy() {
        // unit test
    }

    public void getDamaged(int damage) {
        health -= damage;
        if(health <= 0) {
            isDead = true;
        }
    }
}