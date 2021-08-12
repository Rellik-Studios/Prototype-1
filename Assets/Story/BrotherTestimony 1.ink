-What is it you want? #Character.Brother #Emotion.brother_neutral

    *[Night of the murder] Could you tell me what happened at the night of the murder? #Character.Protagnist
                            Want my alibi? Unfortunately I was home last night.#Character.Brother #Emotion.brother_neutral
                            I'll just tell you that the old man had many enemies. This outcome doesn't surprise me. #Character.Brother #Emotion.brother_neutral
                            Everyone in this town was after his money. #Character.Brother #Emotion.brother_neutral
->END
    *[The Duke]   Can you tell me about Duke Whitmore? #Character.Protagnist
                        Great Duke Whitmore... what was so great about him anyway? #Character.Brother #Emotion.brother_snarky
                        He and I didn't really see... #Character.Brother #Emotion.brother_neutral
                        Eye to eye. #Character.Brother #Emotion.brother_angry 
                        I see, so  you two weren't close... #Character.Protagnist
                        Let's just say he had it coming. #Character.Brother #Emotion.brother_neutral
->END
    *[Show Knife.0knife2] Can you tell me about this knife?  
    #Interaction.show(Knife) 
        Can you tell me about this knife? #Character.Protagnist
        That's my brother's signature design. #Character.Brother #Emotion.brother_neutral
        He only gives these knives to the <color=red><b>people closest to him</b></color>. #Character.Brother #Emotion.brother_sad  #Interaction.modify(knife3)
        What about you, do you have one? #Character.Protagnist
        ...You should be getting on with your investigation, Detective. #Character.Brother #Emotion.brother.sad 
        Hm... #Character.Protagnist #Interaction.modify(knife3)
 ->END       
    *[Show Torn Photo.0RippedPhoto2]
        #Interaction.show(rippedPhoto) 
        That's the Duke... my brother, as a child. #Character.Brother #Emotion.brother_sad
        Photo's ripped, but I think it was his childhood buddy next to him in that photo.
        #Character.Brother #Emotion.brother_neutral
        I don't know much about him. That box looks familiar though. #Interaction.modify(rippedPhoto3)
        #Character.Brother #Emotion.brother_neutral
                    
->END            