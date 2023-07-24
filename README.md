# spaceinvaders01

<p>Basic ecreation of the original Space Invaders in C#/MonoGame.</p>
<p>
<img src=https://github.com/defaultroot1/spaceinvaders01/blob/master/spaceInvadersScreenshot.png>
</p>
<p>After making Breakout I thought this would be very straightforward, afterall on paper it's just Breakout with lasers! But there were a few complexities I didn't account for until I got coding, and ran into a few bugs that delayed things</p>
<p>I had the game 90% complete with static sprites before deciding to animate the aliens. This turned out to be a big mistake! I was using Texture.Width/Height for a lot of calculations so it introduced a lot of bugs and refactoring. I thought it would have been relatively easy to go from static sprites to animated, and that it would be common to use static sprite as a placeholder in early game development befor replacing with aninmation. That might still be the case, but it's definitely something that needs to be planned. Lesson learnt.</p>
<p>I'm very happy with the alien swarm; realising that aliens only fire when there's no alien in front of them had me worried, but I was surprised by how quickly I had that coded. Same for the destructable bunkers, which were fun to code.</p>
<p>There's a lot of messy stuff, some horrible hardcoded numbers, and I still struggle to decide what the best approach is between using public static classes or instances being passed around. But this was a good learning experience. On to the next game!</p>