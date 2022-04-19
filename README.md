I have builded a simple Blog :

1)The system should allow the possibility to add posts and comment in the posts ( DONE)
2)Users must be able to register with the system beforeposting or commenting (DONE if not signed in - > sign in or register) 
3)The post should have a Title a Photo and the text of the post (DONE)
4)Any yser can comment on a post (DONE)
5)Posts are divided into categories predifined by system adm (DONE)
6)A post can have more than one category (unclear how to do that  so i made it with one category onlythat you can select from the options the adm set wich are saved in the database too )
7)The system has the ability to search for text posts or filter by category (Search works fine , category filter had a problem when i implemented the filter by categories option , 
ive posted the logic as a comment but it doesnt implement after i implemented the search, must be a bug or smth )



EXTRAS : 

Created a admin too wich can EDIT(everything even the photos or categories ) or REMOVE posts that he doesnt want to be in the blog.



Technologies : .net 5 core MVC . 
Repository Pattern used .
Page doesnt refresh on the comment (DONE)
