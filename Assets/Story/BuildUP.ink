->Question_1

=== Question_1 ===

What is the first clue of the killer #Character. 
    + They are a male #Character.Player
    ->Question_2
    +They are a female #Character.Player #Interaction.Hurt
    ->Question_1
    ->DONE
    
=== Question_2 ===

Clue to Identify the player #Character. 
    +Bottle #Character.Player #Interaction.Hurt
    ->Question_2
    +Tipped over glass #Character.Player #Interaction.Hurt
    ->Question_2
    +Standing glass #Character.Player
    ->Question_3
    -> DONE
    
    === Question_3 ===
The standing glass has #Character. 
    +Fingerprints #Character.Player #Interaction.Hurt
    ->Question_3
    +No fingerprints #Character.Player
    ->Question_4
    ->DONE
    
    === Question_4 ===
The duke's brother is innocent because: 
    +Pills #Character.Player #Interaction.Hurt
    ->Question_4
    +Testimony #Character.Player #Interaction.Hurt
    ->Question_4
    +Knife  #Character.Player
    ->Question_5
    -> DONE

    
    === Question_5 ===
What is weird?
    +The duke's will? #Character.Player #Interaction.Hurt
    ->Question_5
    +The duke's body? #Character.Player #Interaction.Hurt
    ->Question_5
    +The duke's death? #Character.Player
    ->Question_6
    -> DONE
    
    === Question_6 ===
What evidence is strange?
    +Bottle #Character.Player #Interaction.Hurt
    ->Question_6
    +Wine Standing #Character.Player #Interaction.Hurt
    ->Question_6
    +Wine tipped
    ->END
    ->DONE


    
-> END

