
using UnityEngine;
public class Bomb : MonoBehaviour
{
    public float explosionRadius = 5f;      // ��ը�ķ�Χ
    public float initialExplosionDelay = 2f; // ��ʼը���ı�ը�ӳ�
    public float chainExplosionDelay = 1f;   // ��������ը���ı�ը�ӳ�
    public bool hasExploded = false;

    void Start()
    {
        // ��ʼʱ���ӳ�һ��ʱ��������ʼը��
        Invoke("Explode", initialExplosionDelay);
    }

    public void TriggerExplosion()
    {
        if (!hasExploded)
        {
            // ������ʱ���ӳ�һ��ʱ�䱬ը
            Invoke("Explode", chainExplosionDelay);
        }
    }

    void Explode()
    {
        if (hasExploded) return;

        hasExploded = true;

        // ��ӱ�ըЧ�������磬������Ч�������ȣ�
        Debug.Log("Bomb exploded at " + transform.position);

        // �ҵ������ڱ�ը��Χ�ڵ�����
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Bomb bomb = nearbyObject.GetComponent<Bomb>();
            if (bomb != null && bomb != this && !bomb.hasExploded)
            {
                // ������Χ�ڵ�����ը�����ӳٱ�ը��
                bomb.TriggerExplosion();
            }
        }

        // ���������������ը�����󣬻�������һЩ������Ч��
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        // �ڱ༭���п��ӻ���ը��Χ
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}