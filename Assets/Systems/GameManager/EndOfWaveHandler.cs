using UnityEngine;
using UnityEngine.UI;

public class EndOfWaveHandler : MonoBehaviour
{

    
    private WaveHandler waveHandler;
    private int currentWaveNumber;
    
    [SerializeField] Text waveFinishedText;

    [SerializeField] Text descriptionText;
    [SerializeField] Text option1Text;
    [SerializeField] Text option2Text;
    [SerializeField] Text resultText;
    public bool option1 { get; private set; }
    public bool option2 { get; private set; }
    public bool option3 { get; private set; }
    public bool option4 { get; private set; }

    public bool[,] optionsPicked { get; private set; }

    public int ruthlessnessScore { get; private set; } = 0; // Aggression, cruelty, vengeance
    public int nihilismScore { get; private set; } = 0;     // Apathy, burnout, detachment
    public int defianceScore { get; private set; } = 0;     // Rebellion, risk-taking, independence
    public int stoicismScore { get; private set; } = 0;     // Restraint, empathy, honor, logic
    private PlayerMovement playerMovement;
    private PlayerHealth playerHealth;
    private PlayerAttack playerAttack;

    public void OnOption1Selected()
    {
        option1 = true;
        option2 = false;
        option3 = false;
        option4 = false;
    }
    public void OnOption2Selected()
    {
        option2 = true;
        option1 = false;
        option3 = false;
        option4 = false;
    }
    public void OnOption3Selected()
    {
        option3 = true;
        option4 = false;
        option1 = false;
        option2 = false;
    }
    public void OnOption4Selected()
    {
        option4 = true;
        option1 = false;
        option2 = false;
        option3 = false;
    }

    private void Awake()
    {
        optionsPicked = new bool[9, 4];

        GameObject waveSystem = GameObject.Find("WaveSystem");
        waveHandler = waveSystem.GetComponent<WaveHandler>();

        currentWaveNumber = waveHandler.currentWave + 1;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        playerHealth = player.GetComponent<PlayerHealth>();
        playerAttack = player.GetComponent<PlayerAttack>();
    }
    public void HandleWaveFinishedText()
    {
        currentWaveNumber = waveHandler.currentWave + 1;
        waveFinishedText.text = ("Wave " + currentWaveNumber + " finished. (" + currentWaveNumber + "/10)");
    }
    public void SetStory()
    {
        switch (currentWaveNumber)
        {
            case 1:
                descriptionText.text = "You killed all of your opponents, they were weaker than you. Now, you are not very hopeless to survive in this deadly arena.";
                option1Text.text = "i did what i had to do.";
                option2Text.text = "bring me more enemies so i can split them into two!";
                break;
            case 2:
                descriptionText.text = "You found yourself thinking about your past life, you were an excellent commander and the king put you into this arena because you refused to kill some peasants. Now you see those peasants watching and making fun of you.";
                option1Text.text = "I will kill them when i get out of here!!";
                option2Text.text = "They are just uneducated people in the tyranny.";
                break;
            case 4:
                descriptionText.text = "Like everyone who has suffered a great deal in life, you too have asked yourself the classic question: Does life have meaning?";
                option1Text.text = "Yes.";
                option2Text.text = "No.";

                break;
            case 5:
                descriptionText.text = "The king has come to see you this evening and said \"you're doing a great job here. if you survive, maybe i can let you get your position back.\"";
                option1Text.text = "Your crown will fall with your head. (rebellion)";
                option2Text.text = "My king, i would appreciate that. (obey)";
                break;
            case 6:
                descriptionText.text = "You're cheering with joy at surviving another round. Then you notice an opponent you thought you'd killed is groaning in pain on the ground.";
                option1Text.text = "Be merciful";
                option2Text.text = "kill him";
                break;
            case 7:
                descriptionText.text = "in the middle of night, You are sent into the arena, but no enemies come. One gate across from you stands open, leading into darkness. The announcer says nothing.";
                option1Text.text = "Enter the gate";
                option2Text.text = "Stay in the arena";
                break;
            case 8:
                descriptionText.text = "in the darkness of your cell, you started to think what to do after you escape here, After thinking it through carefully, you see there are two options. You will be retired or continue your carrier and lead armies.";
                option1Text.text = "Strength and honor!";
                option2Text.text = "I am tired of this nonsense.";
                break;

            case 9:
                if (optionsPicked[4,0] == true) 
                {
                    descriptionText.text = "Tomorrow will be your last fight. Since you displayed rebellious behavior towards the king, you will fight against the king himself. (The King is the strongest opponent in the game)";
                    option1Text.text = "Bring it on!";
                    option2Text.text = "Maybe I can put posion on my sword...";
                }
                if (optionsPicked[4, 1] == true) 
                {
                    descriptionText.text = "Tomorrow will be you last fight, In this arena, a gladiator fights the kingdom's strongest animal to escape. It is a bear named \"GOR\". Many great warriors died under its furious claws. (GOR is the second strongest opponent after The King).";
                    option1Text.text = "review fighting tactics all night";
                    option2Text.text = "i need to sleep.";
                }
                break;
            
        }
    }

    public void SetModifiers()
    {
        switch (currentWaveNumber)
        {
            case 1:
                if (option1 == true && option2 == false)
                {
                    resultText.text = "This attitude made you more temperate. (+40% health)";
                    playerHealth.SetHealthByPercent(40);
                    optionsPicked[0,0] = true;
                    stoicismScore += 1;
                    
                }
                if (option1 == false && option2 == true)
                {
                    {
                        resultText.text =("This attitude made you more agressive and unhealthy. (+70% attack, -20% health)");
                        playerAttack.SetPlayerAttackByPercent(70);
                        playerHealth.SetHealthByPercent(-20);
                        optionsPicked[0,1] = true;
                        ruthlessnessScore += 1;
                    }

                }
                break;
            case 2:
                if (option1 == true && option2 == false)
                {
                    resultText.text = "Now you are fueled with rage. (+15% attack speed)";
                    playerAttack.SetAttackCooldownByPercent(-15);
                    optionsPicked[1,0] = true;
                    ruthlessnessScore += 1;
                    

                }
                if (option1 == false && option2 == true)
                {
                    
                        resultText.text = ("You kept your anger your for your next opponents. (+20 health, +10% movement speed)");
                        playerMovement.SetMoveSpeedByPercent(10);
                        playerHealth.SetHealthByPercent(20);
                        optionsPicked[1,1] = true;
                    stoicismScore += 1;
                    

                }
                break;
            case 3:
                if (option1) 
                {
                    resultText.text = ("Yellow cat reminds you playfulness and mobility. (+5% movement speed, +10% attack)");
                    playerMovement.SetMoveSpeedByPercent(5);
                    playerAttack.SetPlayerAttackByPercent(10);
                    optionsPicked[2,0] = true;
                    defianceScore += 1;
                }
                if (option2) 
                {
                    resultText.text = ("Black cat reminds you loyalty and affection. (+20% health)");
                    playerHealth.SetHealthByPercent(20);
                    optionsPicked[2, 1] = true;
                    stoicismScore += 1;
                }
                if (option3) 
                {
                    resultText.text = ("White cat reminds you clouds in the sky. (+10% movement speed)");
                    playerMovement.SetMoveSpeedByPercent(10);
                    optionsPicked[2, 2] = true;
                    nihilismScore += 1;
                }
                if (option4) 
                {
                    resultText.text = ("Tabby cat reminds you durability and resilience (+10% health, +10% attack)");
                    playerHealth.SetHealthByPercent(10);
                    playerAttack.SetPlayerAttackByPercent(10);
                    optionsPicked[2, 3] = true;
                    ruthlessnessScore += 1;
                }
                break;
            case 4:
                if (option1 == true && option2 == false) 
                {
                    resultText.text = ("Live for the meaning! (+20% health)");
                    playerHealth.SetHealthByPercent(20);
                    optionsPicked[3,0] = true;
                    defianceScore += 1;
                    stoicismScore += 1;
                }
                if (option1 == false && option2 == true) 
                {
                    resultText.text = ("Nature does not reward every realistic approach. (-10% health)");
                    playerHealth.SetHealthByPercent(-10);
                    optionsPicked[3,1] = true;
                    defianceScore += 2;

                }
                break;
            case 5:
                if (option1 == true && option2 == false)
                {
                    resultText.text = ("Your final fight to escape the arena will be against the king himself.");
                    optionsPicked[4,0] = true;
                    defianceScore += 2;
                    
                }
                if (option1 == false && option2 == true)
                {
                    resultText.text = ("It pains you to submit to a cruel king. (-10% health)");
                    playerHealth.SetHealthByPercent(-10);
                    optionsPicked[4,1] = true;
                    stoicismScore += 1;
                    nihilismScore += 1;
                }
                break;
            case 6:
                if (option1 == true && option2 == false) 
                {
                    resultText.text = ("People watching you shout: \"The merciful gladiator!\" (+15% health, +10% attack)");
                    playerHealth.SetHealthByPercent(15);
                    playerAttack.SetPlayerAttackByPercent(10);
                    optionsPicked[5,0] = true;
                    stoicismScore += 2;
                    
                    
                    
                }
                if (option1 == false && option2 == true) 
                {
                    resultText.text = ("This move satisfied the king and he gave you a sharper sword (+20% attack)");
                    playerAttack.SetPlayerAttackByPercent(20);
                    optionsPicked[5,1] = true;
                    ruthlessnessScore += 2;
                }
                break;
            case 7:
                if (option1 == true && option2 == false) 
                {
                    resultText.text = ("You stepped into the unknown. Whatever waited inside sharpened your instincts. (+5% movement speed, +10% attack speed)");
                    playerMovement.SetMoveSpeedByPercent(5);
                    playerAttack.SetAttackCooldownByPercent(-10);
                    optionsPicked[6, 0] = true;
                    defianceScore += 1;

                }
                if (option2 = false && option1 == true) 
                {
                    resultText.text = ("You chose patience over curiosity. Waiting hardened your body, but dulled your reflexes. (+10% health, -5% attack speed)");
                    playerHealth.SetHealthByPercent(10);
                    playerAttack.SetAttackCooldownByPercent(5);
                    optionsPicked[6, 1] = true;
                    stoicismScore += 1;

                }
                break;
            case 8:
                if (option1 == true && option2 == false)
                {
                    resultText.text = "The idea of planning to keep killing people will give you motivation in the field tomorrow.(+20% attack)";
                    playerAttack.SetPlayerAttackByPercent(20);
                    optionsPicked[7, 0] = true;
                    ruthlessnessScore += 1;
                    stoicismScore += 1;
                }
                if (option1 == false && option2 == true)
                {
                    resultText.text = "The idea of having to kill more people to survive will demoralize you in the field tomorrow (-5% attack)";
                    playerAttack.SetPlayerAttackByPercent(-5);
                    optionsPicked[7, 1] = true;
                    nihilismScore += 2;
                }
                break;
            case 9:
                if (optionsPicked[4, 0] == true)
                {
                    if (option1 == true && option2 == false) 
                    {
                        resultText.text = "Your anger towards the king will come in handy in the fight. (+75% attack, +75% health)";
                        playerAttack.SetPlayerAttackByPercent(75);
                        playerHealth.SetHealthByPercent(75);
                        optionsPicked[8,0] = true;
                        defianceScore += 2;
                    }
                    if (option2 == false && option1 == true)
                    {
                        resultText.text = "The poison in the sword, if administered in a sufficient dose, could easily kill a person. (+200% attack)";
                        playerAttack.SetPlayerAttackByPercent(200);
                        optionsPicked[8,1] = true;
                        ruthlessnessScore += 2;
                    }
                }
                if ((optionsPicked[4, 1]) == true)
                {
                    if (option1 == true && option2 == false)
                    {
                        resultText.text = "You meticulously planned how you were going to fight a bear, but you couldn't sleep. (-20% health, +80% attack)";
                        playerHealth.SetHealthByPercent(-20);
                        playerAttack.SetPlayerAttackByPercent(80);
                        optionsPicked[8,2] = true;
                        stoicismScore += 2;

                    }
                    if (option1 == false && option2 == true) 
                    {
                        resultText.text = "You slept well and you are ready for your final fight. (+50% health)";
                        playerHealth.SetHealthByPercent(50);
                        optionsPicked [8,3] = true;
                        nihilismScore += 2;
                    }
                }
                break;
            
        }

    }
}
