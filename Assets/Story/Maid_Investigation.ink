->Stuff
=== Stuff ===
-I'm the head maid of the duke's mansion, #Emotion.maid_neutral #Character.Maid
If you need anything let me know, #Emotion.maid_neutral #Character.Maid
    *[Night of the murder] I was in the kitchen preparing the food #Emotion.maid_neutral #Character.Maid
                            Are you suspecting I'm the killer? #Emotion.maid_irritated #Character.Maid
                            I'll have you know that I've been working with the duke for a very long time.  #Emotion.maid_irritated #Character.Maid
                            I had nothing but respect for duke  #Emotion.maid_irritated #Character.Maid
    ->DONE
    
    *[Is anything missing.0MissingItem1]
     There is something missing which is a box, The box was very important to the duke #Emotion.maid_neutral #Character.Maid
     I recall it was a pretty lil box with <color=red>golden detail</color> #Interaction.modify(tornPhoto2)
    ->Stuff
    *[Show torn Photo.0TornPhoto2]
    blah #Interaction.show(tornPhoto) #Skip.0
    Yes that is the duke as a child, and that's the box that's currently missing #Emotion.maid_neutral #Character.Maid
    ->DONE
->DONE