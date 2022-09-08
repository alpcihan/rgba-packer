# rgba-packer
![video](https://user-images.githubusercontent.com/37274614/189114982-34a5b8ec-d2b2-40f5-95ba-c228cf7895d1.gif)

Easy-to-use RGBA texture packer package for Unity to pack images and export them as PNG file.

## Getting started
- Add the package to the Unity project.
- Go to ``` Unity Editor > Window > RGBA Packer ``` to open the RGBA Packer window.

## RGBA Packer window
### Output Resolution

Region to set the resolution of the output image.

- ```X```: width of the output image in pixels.

- ```Y```: height of the output image in pixels.


### Red Green Blue Alpha Channels

5 separate regions to control the red, green, blue and alpha channels of the output image.
* ```Object field```: component to assign a texture to read from. 
  - It assigns the **red channel** of the input image to the corresponding channel of the output image.
  - If no texture gets assigned it inputs 1.0 to the given channel.
 
* ```Invert channel```: inverts the input value if it gets checked (value to 1.0 - value). 
* ```Pack the textures```: button to calculate and display the packed output image.
* ```Save the packed texture```: button to save the packed texture as ```packed.png``` to the ```PackedImages``` folder under the root of the project.
  - If ```PackedImages``` folder does not exist, it creates one.

## License

[MIT](./LICENSE.md)
