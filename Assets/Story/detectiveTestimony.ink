->Question_1
=== Question_1 ===
-Hello I am Sen, your senior officer, your Senior and your mentor for this investigation. #Character.Sen #Emotion.sen_neutral
    *[About you] Could you tell me a bit about yourself? #Character.Protagnist
                I've been a detective for 20 years. I have a flawless record with the cases I solve, I am NEVER wrong. #Character.Sen #Emotion.sen_snarky
                ->Question_1
    *[Night of the murder] Could you tell me what happened at the night of the murder? #Character.Protagnist
                            I know there was a party being held at this residence. #Character.Sen #Emotion.sen_neutral
                            Take a look at this article. #Character.Sen #Emotion.sen_neutral #Interaction.addToInventory(Newspaperarticle)
                            ->Question_1
    *[Cause of Death]   Can you tell me the victim's cause of death? #Character.Protagnist
                        The victim was stabbed with a knife. The knife was plunged straight into the heart. #Character.Sen #Emotion.sen_snarky
                        I am certain that is the cause of death. #Character.Sen #Emotion.sen_snarky 
                        I see. #Character.Protagnist #Interaction.addToInventory(seniordetectiveautopsy)
                        ->END            
-> DONE