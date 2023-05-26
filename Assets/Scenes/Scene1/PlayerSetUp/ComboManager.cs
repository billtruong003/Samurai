using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace scene1
{
    public class ComboManager : MonoBehaviour
    {
        Animator ani;
        [SerializeField] UI_Controller attackButton;
        bool attackTrigger;
        public int combo;
        public bool attacking;
        public float comboTiming;
        public float comboTempo;
        //public float randomAttack;
        // Start is called before the first frame update
        void Start()
        {
            ani = GetComponent<Animator>();
            combo = 1;
            comboTiming = 0.5f;
            comboTempo = comboTiming;
        }

        // Update is called once per frame
        void Update()
        {
            attackTrigger = attackButton.attackClick;
            Combo();
        }
        //public void Combo()
        //{
        //    if (Input.GetKeyDown(KeyCode.J) && !attacking)
        //    {
        //        randomAttack = Random.Range(1, 4);
        //        if (Mathf.Round(randomAttack) == 1) 
        //        {
        //            attacking = true;
        //            ani.SetTrigger("Attack1");
        //            Debug.Log("Attack1");
        //        }
        //        else if (Mathf.Round(randomAttack) == 2)
        //        {
        //            attacking = true;
        //            ani.SetTrigger("Attack2");
        //            Debug.Log("Attack2");
        //        }
        //        else if (Mathf.Round(randomAttack) == 3 || Mathf.Round(randomAttack) == 4)
        //        {
        //            attacking = true;
        //            ani.SetTrigger("Attack3");
        //            Debug.Log("Attack3");
        //        }
        //    }
        //    else attacking = false;
        //}
        public void Combo()
        {
            comboTempo -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.J) && comboTempo < 0 || attackTrigger && comboTempo < 0)
            {
                attacking = true;
                ani.SetTrigger("Attack" + combo);
                comboTempo = comboTiming;
            }
            else if (Input.GetKeyDown(KeyCode.J) && comboTempo > 0 && comboTempo < 0.3 || attackTrigger && comboTempo > 0 && comboTempo < 0.2)
            {
                attacking = true;
                combo++;
                if (combo > 3)
                {
                    combo = 1;
                }
                ani.SetTrigger("Attack" + combo);
                comboTempo = comboTiming;
            }
            else attacking = false;
            if (comboTempo < 0)
            {
                combo = 1;
            }
        }
    }
}