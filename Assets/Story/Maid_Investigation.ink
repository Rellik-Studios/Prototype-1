->Stuff
=== Stuff ===
-I'm the head maid of the Duke's mansion, #Emotion.maid_neutral #Character.Maid
If you need anything let me know, #Emotion.maid_neutral #Character.Maid
    *[Night of the murder] I was in the kitchen preparing the food #Emotion.maid_neutral #Character.Maid
                            Are you suspecting I'm the killer? #Emotion.maid_irritated #Character.Maid
                            I'll have you know that I've been working with the Duke for a very long time.  #Emotion.maid_irritated #Character.Maid
                            I had nothing but respect for Duke  #Emotion.maid_irritated #Character.Maid
    ->DONE
    
    *[Is anything missing.0MissingItem1]
     There is something missing which is a box, the box was very important to the Duke #Emotion.maid_neutral #Character.Maid
     I recall it was a pretty lil box with <color=red><b>golden detail</b></color> #Interaction.modify(RippedPhoto2)
    ->DONE
    *[Show torn Photo.0RippedPhoto2]
    blah #Interaction.show(rippedPhoto) #Skip.0
    Yes that is the Duke as a child, and that's the box that's currently missing #Emotion.maid_neutral #Character.Maid
    ->DONE
->DONE