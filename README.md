# DES315: Technical Design Methods

This is a research project for DES315, a module in DigiPen SG.
For my part, I am investigating on various technologies used in virtual avatar concerts.

## Six-Point Motion Capture (mocap-six)

This [Interview with COVER](https://www.youtube.com/watch?v=nARBc054hjQ) mentions that they track six points of the body in VR to perform full-body motion capture: head, waist, wrists and ankles. I decided to test this method in Unity.

As I do not have access to VR trackers, I decided to get the positions and rotations of the six points from pre-made animations, then use Unity's Animation Rigging package to perform inverse kinematics (IK).

https://user-images.githubusercontent.com/7701591/139229812-631608d3-3ff1-449c-b180-7c977046abe9.mp4

The outcome is decent, but has a lot of room for improvement. For example, if I implement joint angle constraints in the IK, then we can get more accurate human poses and avoid weird and unnatural rotations.

This method is a cheaper alternative to the more costly option of using motion capture suits. This is especially important for livestreams with many performers at once, which would necessitate motion capture for each performer.

*Packages used: [Animation Rigging](https://docs.unity3d.com/Packages/com.unity.animation.rigging@latest), [Unity-chan!](https://assetstore.unity.com/packages/3d/characters/unity-chan-model-18705)*
