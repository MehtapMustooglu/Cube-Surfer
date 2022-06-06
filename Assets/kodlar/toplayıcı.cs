using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class toplayıcı : MonoBehaviour
{
    
    // Start is called before the first frame update
    GameObject player;
    int height;
    int score = 0;
    public Text score_text;
    public AudioSource finish_sound, collision_sound, game_sound;
    void Start()
    {
       
        player = GameObject.Find("Cube");
        game_sound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        locatePlayer();
        print_score();
    }
    private void locatePlayer()
    {
        player.transform.position = new Vector3(transform.position.x, height + 0.5f, transform.position.z);
        this.transform.localPosition = new Vector3(0, -height, 0);
    }
    private void print_score()
    {
        score = height * 10;
        score_text.text = " " + score;
    }
    public void heightdecrase()
    {
        height--;
    }

    private void Scene_gameOver()
    {
        SceneManager.LoadScene(1); ;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "topla" && other.gameObject.GetComponent<toplanabilirküpler>().Gettoplandimi()==false)
        {
            height += 1;
            Debug.Log(height);
            other.gameObject.transform.parent = player.transform;
            other.gameObject.GetComponent<toplanabilirküpler>().make_collection();
            other.gameObject.GetComponent<toplanabilirküpler>().indexayarla(height);
            other.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
            collision_sound.Play();
        }

        if(other.gameObject.tag == "engel" &&  height < other.gameObject.transform.localScale.y)
        {
            heightdecrase();
            Debug.Log(height + "azaldı");
            PlayerPrefs.SetFloat("forward", 0);
            Invoke("Scene_gameOver",2);
        }


        if (other.gameObject.name == "FinishCube")
        {
            PlayerPrefs.SetFloat("forward", 0 * Time.deltaTime);
            game_sound.Stop();
            finish_sound.Play();

        }
    }
}
