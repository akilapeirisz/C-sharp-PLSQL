CREATE OR REPLACE PROCEDURE lib_db_apeilk_user_create_(name_   IN VARCHAR2,
                           num_    IN NUMBER,
                           street  IN VARCHAR2,
  												 city    IN VARCHAR2,
													 country IN VARCHAR2,
                           email   IN VARCHAR2,
                           uname   IN VARCHAR2,
                           pass    IN VARCHAR2) IS
BEGIN
  INSERT INTO library_db_apeilk_user_tab
  VALUES
  (library_db_apeilk_user_seq_.nextval,
   name_,
   library_db_apeilk_address_type(library_db_apeilk_add_seq_.nextval, num_, street, city, country), 
   email, 
   uname, 
   pass);
  
END lib_db_apeilk_user_create_;
