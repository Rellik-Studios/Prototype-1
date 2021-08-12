->Question_1

=== Question_1 ===

We know one important thing about the killer... #Character.Protagnist #Emotion.null
    + [They are a male] #Character.Player #Skip.2
        We know the suspect is male from the Son's statement. #Character.Protagnist
        His dad mentioned a "him". #Character.Protagnist
    ->Question_2
    +They are a female #Character.Player #Interaction.Hurt #Skip.2
    ->Question_1
    ->DONE
    
=== Question_2 ===

A clue that could help us identify the killer... #Character. 
    +Bottle #Character.Player #Interaction.Hurt #Skip.2
    ->Question_2
    +Tipped over glass #Character.Player #Interaction.Hurt #Skip.2
    ->Question_2
    +[Standing glass] #Character.Player #Skip.2
        There was someone else in the room, the glass was his. #Character.Protagnist
    ->Question_3
    -> DONE
    
    === Question_3 ===
The standing glass has #Character. 
    +Fingerprints #Character.Player #Interaction.Hurt #Skip.2
    ->Question_3
    +[No fingerprints] #Character.Player #Skip.2
        The glass with no fingerprints must be the killer's. #Character.Protagnist
        He was wearing gloves. #Character.Protagnist
        The other glass had the Duke's fingerprints on it. #Character.Protagnist
    ->Question_4
    ->DONE
    
    === Question_4 ===
One important clue that narrows the pool of suspects was:
    +Pills #Character.Player #Interaction.Hurt #Skip.2
    ->Question_4
    +Testimony #Character.Player #Interaction.Hurt #Skip.2
    ->Question_4
    +[Knife]  #Character.Player #Skip.2
        The knife that the Duke was stabbed with, was only given to people close to him... #Character.Protagnist
        Don't you see Rookie? The Duke's Brother is the only who could have done this! #Character.Sen #Emotion.sen_neutral
        That's where you're wrong. #Character.Protagnist
    ->Question_5
    -> DONE
    
        === Question_5 ===
There was someone else close to the Duke...
    +Wine Bottle #Character.Player #Interaction.Hurt #Skip.2
    ->Question_5
    +Newspaper Article #Character.Player #Interaction.Hurt #Skip.2
    ->Question_5
    +[Torn Photo]  #Character.Player #Skip.2
        As you can see, someone tampered with the crimescene, trying to erase their presence in the Duke's life. #Character.Protagnist
        And who do you propose this individual is? #Character.Sen #Emotion.sen_nervous
        Someone who wasn't truthful at the start. #Character.Protagnist 
    ->Question_6
    -> DONE

    
    === Question_6 ===
During my investigation I noticed something was off...
    +The duke's will #Character.Player #Interaction.Hurt #Skip.2
    ->Question_6
    +The duke's body #Character.Player #Interaction.Hurt #Skip.2
    ->Question_6
    +[The duke's death] #Character.Player #Skip.2
        I believe the stab is not what killed the Duke. #Character.Protagnist
    
    ->Question_7
    -> DONE
    
    === Question_7 ===
What really killed him was...
    +Bottle #Character.Player #Interaction.Hurt #Skip.2
    ->Question_7
    +Wine Standing #Character.Player #Interaction.Hurt #Skip.2
    ->Question_7
    +[Wine tipped] #Skip.2
        We found traces of poison when we sampled the tipped glass! #Character.Protagnist
        So? This doesn't change anything, the man is clearly guilty! #Character.Sen #Emotion.sen_snarky
    -->Finale
->DONE
 
 === Finale ===
 This is my proof #Character.Protagonist
 *[Show decisive evidence] #Interaction.show(Seniordetectiveautopsy) #Skip.1
 In the autopsy you stated that the victim was stabbed to death! #Character.Protagonist 
 
 You never mentioned any poison at all!#Character.Protagonist
 Oh really! My bad, I must have made a mistake. #Emotion.sen_nervous #Character.Sen
 You, an experienced detective with 20 years in the business making a mistake this foolish? #Character.Protagonist
 The one who lied to protect himself... #Character.Protagonist
 And pinned the crime on the Duke's brother... #Character.Protagonist
 The one who really killed the Duke... #Character.Protagonist
 was you, Detective Sen Akito! #Character.Protagonist
 
 You-you don't have any proof! #Emotion.sen_nervous #Character.Sen
 
 Oh yeah? So you don't mind if we search your apartment for a certain "item" right? #Character.Protagonist
 
 Grr... Foiled by a rookie. #Emotion.sen_angry #Character.Sen
 I solved the case! #Character.Protagonist #Interaction.Win
->DONE
    
-> END

