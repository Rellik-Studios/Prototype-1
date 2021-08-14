->Question_1

=== Question_1 ===

We know one important thing about the killer... #Character.Rook #Emotion.null
    + [They are a male] #Character.Rook #Skip.2
        We know the suspect is male from the Son's statement. #Character.Rook
        His dad mentioned a "him". #Character.Rook
    ->Question_2
    +They are a female #Character.Rook
    Wait that's wrong #Character.Rook #Interaction.Hurt #Skip.2
    ->Question_1
    ->DONE
    
=== Question_2 ===

A clue that could help us identify the killer was in the room... #Character. 
    +Bottle #Character.Rook 
    Wait that's wrong #Character.Rook #Interaction.Hurt #Skip.2
    ->Question_2
    +Tipped over glass #Character.Rook 
    Wait that's wrong #Character.Rook #Interaction.Hurt #Skip.2
    ->Question_2
    +[Standing glass] #Character.Rook #Skip.2
        There was someone else in the room, the glass was the kiler's. #Character.Rook
    ->Question_3
    -> DONE
    
    === Question_3 ===
The standing glass has... #Character. 
    +Fingerprints #Character.Rook
    Wait that's wrong #Character.Rook #Interaction.Hurt #Skip.2
    ->Question_3
    +[No fingerprints] #Character.Rook #Skip.2
        The glass with no fingerprints must be the killer's. #Character.Rook
        He was wearing gloves. #Character.Rook
        The other glass had the Duke's fingerprints on it. #Character.Rook
    ->Question_4
    ->DONE
    
    === Question_4 ===
One important clue that narrows the pool of suspects was...#Character. 
    +Pills #Character.Rook #Interaction.Hurt #Skip.2
    ->Question_4
    +Testimony #Character.Rook #Interaction.Hurt #Skip.2
    ->Question_4
    +[Knife]  #Character.Rook #Skip.2
        The knife that the Duke was stabbed with, was only given to people close to him... #Character.Rook
        Don't you see Rookie? The Duke's Brother is the only who could have done this! #Character.Sen #Emotion.sen_explaining
        That's where you're wrong. #Character.Rook
    ->Question_5
    -> DONE
    
        === Question_5 ===
There was someone else close to the Duke... #Character. 
    +Wine Bottle #Character.Rook
    Wait that's wrong #Character.Rook #Interaction.Hurt #Skip.2
    ->Question_5
    +Newspaper Article #Character.Rook 
    Wait that's wrong #Character.Rook #Interaction.Hurt #Skip.2
    ->Question_5
    +[Torn Photo]  #Character.Rook #Skip.2
        As you can see, someone tampered with the crimescene, trying to erase their presence in the Duke's life. #Character.Rook
        And who do you propose this individual is? #Character.Sen #Emotion.sen_nervous
        Someone who wasn't truthful at the start. #Character.Rook 
    ->Question_6
    -> DONE

    
    === Question_6 ===
During my investigation I noticed something was off... #Character. 
    +The pills #Character.Rook 
    Wait that's wrong #Character.Rook #Interaction.Hurt #Skip.2
    ->Question_6
    +The duke's body #Character.Rook 
    Wait that's wrong #Character.Rook #Interaction.Hurt #Skip.2
    ->Question_6
    +[Cause of death] #Character.Rook #Skip.2
        I believe the stab is not what killed the Duke. #Character.Rook
    
    ->Question_7
    -> DONE
    
    === Question_7 ===
What really killed him was... #Character. 
    +Bottle #Character.Rook 
    Wait that's wrong #Character.Rook #Interaction.Hurt #Skip.2
    ->Question_7
    +Wine Standing #Character.Rook 
    Wait that's wrong #Character.Rook #Interaction.Hurt #Skip.2
    ->Question_7
    +[Wine tipped] #Skip.2
        We found traces of poison when we sampled the tipped glass! #Character.Rook
        So? This doesn't change anything, the man is clearly guilty! #Character.Sen #Emotion.sen_snarky
    -->Finale
->DONE
 
 === Finale ===
 This is my proof #Character.Rook
 *[Show decisive evidence] #Interaction.show(Seniordetectiveautopsy) #Skip.1
 In the autopsy you stated that the victim was stabbed to death! #Character.Rook 
 
 You never mentioned any poison at all!#Character.Rook
 Oh really! My bad, I must have made a mistake. #Emotion.sen_nervous #Character.Sen
 You, an experienced detective with 20 years in the business making a mistake this foolish? #Character.Rook
 The one who lied to protect himself... #Character.Rook
 And pinned the crime on the Duke's brother... #Character.Rook
 The one who really killed the Duke... #Character.Rook
 was you, Detective Sen Akito! #Character.Rook
 
 You-you don't have any proof! #Emotion.sen_nervous #Character.Sen
 
 Oh yeah? So you don't mind if we search your apartment for a certain "item" right? #Character.Rook
 
 Grr... Foiled by a rookie. #Emotion.sen_angry #Character.Sen
 I solved the case! #Character.Rook #Interaction.Win
->DONE
    
-> END

