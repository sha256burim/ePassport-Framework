<h>ePassport-Framework: electronic pass framework for user data managment in a passport style json data structure. </h>

Initial documentation

~~~~~~~ePassport~~~~~~~~

So this programs purpose is to be a digital passport of sorts that is encrypted and will serve as both
a client and a server of sorts for managing a users personal data

The server side of the code will be doing the confirmation and the generating of the passport data as follows:

-Get information from user
-generate seed and hash code for the user
-Generate passport file with passport filetype that includes the users encrypted data and a seed file
-Export ePassport and seed file 

Information from the user should include Name and all that stuff but also personal id numbers. 
On another note, the filesize should be small enough that the data can be stored in a swipe or digital card

<li>Note 1: User data should be read from a config type file like a generated .txt file where the info will then 
be parsed from. In the future it could be a browser based UI where it will save data to a .json file. 
Un-encrypted if it's run locally and encrypted if it's run remotely.

<li>Note 2: Think about including an image to the saved data. 

<li>Note 3: Create API so that users can implement their own uses for the ePassport

<li>Note 4: Make GUI

<li>Note 5: Make select data available depending on what data needs authenticating. 

<li>Note 6: USe microsoft MVC for the browser based GUI

<li>Note 7: user data structure should be made modifyable by making the code dynamic, generating classes from a .json file could be one way to go. 7</li>
