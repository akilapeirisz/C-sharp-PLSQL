CREATE OR REPLACE PROCEDURE lib_db_apeilk_address_search_(se_id_ IN NUMBER, country OUT VARCHAR2) IS
  CURSOR Ret_val IS
    SELECT country FROM library_db_apeilk_address_tab
    WHERE address_id=se_id_;
  BEGIN
    OPEN Ret_val;
    FETCH Ret_val INTO country;
    IF (Ret_val %NOTFOUND) THEN
		  country := 'Error: Row not found';
    END IF;
    CLOSE Ret_val;
  END lib_db_apeilk_address_search_;
