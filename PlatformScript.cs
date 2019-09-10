using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {
   public Vector3 From; //Точка 1
    public Vector3 To; //Точка 2
    public float time; //Время
    private bool toDir; //Определяет, в какую сторону идти
    bool facingRight = true;
    public float move;

    void Update()
    {
        //Рассчитываем скорость, так-как MoveTowards использует скорость, а не время. Для этого берем расстояние и делим на время.
        float speed = Mathf.Abs((To - From).magnitude) / time;
        //Это переключает направления
        if (transform.position == To)
            toDir = false;
        else if (transform.position == From)
            toDir = true;
        //А это, собственно, двигает
        if (toDir)
            transform.position = Vector3.MoveTowards(transform.position, To, speed);
        else
            transform.position = Vector3.MoveTowards(transform.position, From, speed);
    }
        private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.transform.parent = gameObject.transform;
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.transform.parent = null;
    }
}
