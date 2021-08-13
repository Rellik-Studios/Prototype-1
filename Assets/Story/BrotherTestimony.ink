VAR rippedPhoto = true
VAR knife = true
VAR done = 0

->Stuff

=== Stuff ===
knife2 #Function.setknife
rippedphoto2 #Function.setrippedphoto
-What is it you want? #Character.Brother #Emotion.brother_neutral

    *[Night of the murder] Could you tell me what happened at the night of the murder? #Character.Rook
                            Want my alibi? Unfortunately I was home last night.#Character.Brother #Emotion.brother_neutral
                            I'll just tell you that the old man had many enemies. This outcome doesn't surprise me. #Character.Brother #Emotion.brother_snarky
                            Everyone in this town was after his money. #Character.Brother #Emotion.brother_angry
    ->Stuff
    *[The Duke]   Can you tell me about Duke Whitmore? #Character.Rook
                        Great Duke Whitmore... what was so great about him anyway? #Character.Brother #Emotion.brother_snarky
                        He and I didn't really see... #Character.Brother #Emotion.brother_neutral
                        Eye to eye. #Character.Brother #Emotion.brother_angry 
                        I see, so  you two weren't close... #Character.Rook
                        Let's just say he had it coming. #Character.Brother #Emotion.brother_neutral
    
    ->Stuff            
    
     *{knife}[Show Knife] Can you tell me about this knife?  
    #Interaction.show(Knife) #Character.Protagonist
        That's my brother's signature design. #Character.Brother #Emotion.brother_neutral
        He only gives these knives to the people closest to him. #Character.Brother #Emotion.brother_sad
        What about you, do you have one? #Character.Rook
        ...You should be getting on with your investigation, Detective. #Character.Brother #Emotion.brother_sad
        Hm... #Character.Rook
        #Interaction.modify(knife3)
        {done ==1:
    #Interaction.talked(true)
  - else:
    ~done++
}
        ->Stuff
    *{rippedPhoto}[Show Torn Photo]
         That's the Duke... my brother, as a child. #Character.Brother #Emotion.brother_sad #Interaction.show(rippedPhoto)
        Photo's ripped, but I think it was his childhood buddy next to him in that photo.
        #Character.Brother #Emotion.brother_neutral
        I don't know much about him. That box looks familiar though. 
        #Character.Brother #Emotion.brother_neutral
        #Interaction.modify(rippedPhoto3)
        {done ==1:
    #Interaction.talked(true)
  - else:
    ~done++
}
    ->Stuff
    *->
    I have nothing more to say  #Character.Brother #Emotion.brother_neutral
    ->DONE
    
    
    
=== function setknife(value)
~ knife = value

=== function setrippedphoto(value)
~ rippedPhoto = value