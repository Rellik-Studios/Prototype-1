VAR missingItem = true
VAR rippedPhoto = true
VAR done = 0
->Stuff
=== Stuff ===

missingitem1 #Function.setmissingitem 
rippedphoto2 #Function.setrippedphoto 
-I'm the head maid of the Duke's mansion. #Emotion.maid_neutral #Character.Maid
If you need anything let me know. #Emotion.maid_neutral #Character.Maid
And please, don't touch anything. #Emotion.maid_irritated #Character.Maid
    *  -> 
    I have nothing more to say #Emotion.maid_neutral #Character.Maid
    blah
    ->DONE
    *[Night of the murder] I was in the kitchen preparing the food #Emotion.maid_neutral #Character.Maid
                            Are you suspecting I'm the killer? #Emotion.maid_irritated #Character.Maid
                            I'll have you know that I've been working with the Duke for a very long time.  #Emotion.maid_irritated #Character.Maid
                            I had nothing but respect for Duke  #Emotion.maid_irritated #Character.Maid
                            blah
                            
    ->DONE
    
    
    * {missingItem} [Is anything missing]
     There was a box in that spot, it was very important to the Duke. #Emotion.maid_neutral #Character.Maid  
     
     I recall it was a pretty little box with <color=red><b>golden details</b></color>. 
     You didn't snatch it did you? I'd be honest if I were you. #Emotion.maid_irritated #Character.Maid
     No ma'am. #Character.Protagonist
     blah
    ->DONE
    *{rippedPhoto} [Show Ripped Photo]
    Yes that is the Duke as a child, and he's holding the box that's missing...#Emotion.maid_neutral #Character.Maid #Interaction.show(rippedPhoto) 
    blah
    
    ->DONE
->DONE

=== function setmissingitem(value)
~ missingItem = value

=== function setrippedphoto(value)
~ rippedPhoto = value
