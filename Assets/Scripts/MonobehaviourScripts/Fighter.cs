using UnityEngine;
using System.Collections;
using System;
using System.Text;

public class Fighter : MonoBehaviour
{
    #region Member Variables

    public FighterAttributes Attributes;

    public Boolean IsPlayer = false;

    #endregion

    #region MonoBehaviour Events

    void Start()
    {
        if (IsPlayer == true)
        {
            Attributes = ModelControl.GetPlayerAttributesFromModel();
        }
    }

    void Update()
    {
        CheckForPlayerAttributes();
    }

    void OnDestroy()
    {
        if (IsPlayer == true)
        {
            ModelControl.UpdatePlayerAttributesInModel(Attributes);
        }
    }

    #endregion

    #region Member Methods

    public void CheckForPlayerAttributes()
    {
        if (Attributes != null)
        {
            return;
        }

        if ( (IsPlayer == true) && (Attributes == null) )
        {
            Attributes = ModelControl.GetPlayerAttributesFromModel();
        }
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            Attributes.CurrentHP -= damage;
            StillAlive();
        }
    }

    public void RestoreHP(int heal)
    {
        Attributes.CurrentHP += heal;

        if (Attributes.CurrentHP > Attributes.TotalMaxHP)
        {
            Attributes.CurrentHP = Attributes.TotalMaxHP;
        }
    }

    public void AttackTarget(GameObject prey)
    {
        ////////////////////////////////////////////
        //Local Variables

        GameObject messageWindow = GameObject.FindWithTag(TagKeys.MESSAGE_WINDOW_KEY);

        Fighter preyFighter;

        int damage = 0;

        ////////////////////////////////////////////

        preyFighter = prey.GetComponent<Fighter>();

        damage = Attributes.TotalPower - preyFighter.Attributes.TotalDefense;

        if (damage > 0)
        {
            messageWindow.GetComponent<MessageWindow>().AddText(this.name + " attacks " + prey.name + " for " + damage.ToString() + " hit points.");
            preyFighter.TakeDamage(damage);
        }

        else
        {
            messageWindow.GetComponent<MessageWindow>().AddText(this.name + " attacks " + prey.name + ", but it has no effect!");
        }
    }

    #endregion

    #region Private Methods

    private void StillAlive()
    {
        ///////////////////////////////////////////////
        //Local Variables

        GameObject gameController;
        GameObject messageWindow = GameObject.FindWithTag(TagKeys.MESSAGE_WINDOW_KEY);

        ///////////////////////////////////////////////

        if (Attributes.CurrentHP <= 0)
        {
            if (IsPlayer == true)
            {
                gameObject.GetComponent<InputAction>().enabled = false;

                messageWindow.GetComponent<MessageWindow>().AddText("Game Over.  Press any key to restart.");
            }

            else
            {
                gameController = GameObject.FindWithTag(TagKeys.MAIN_CONTROLLER_KEY);

                messageWindow.GetComponent<MessageWindow>().AddText(String.Format("{0} is dead!", gameObject.name));

                gameController.GetComponent<MonsterController>().RemoveMonster(gameObject);

                AddXP.Start(Attributes.XP);

                GameObject.Destroy(gameObject);
            }
        }
    }

    #endregion
}
