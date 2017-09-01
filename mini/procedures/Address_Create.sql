CREATE OR REPLACE PROCEDURE lib_db_apeilk_address_create_(num_     IN VARCHAR2,
                               street  IN VARCHAR2,
                               city    IN VARCHAR2,
                               country IN VARCHAR2) IS
  BEGIN
    INSERT INTO library_db_apeilk_address_tab
    VALUES
      (library_db_apeilk_add_seq_.nextval, num_, street, city, country);
  END lib_db_apeilk_address_create_;
