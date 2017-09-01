CREATE OR REPLACE PROCEDURE lib_db_apeilk_address_update_(up_id_ IN NUMBER,
                               up_num_     IN VARCHAR2,
                               up_street  IN VARCHAR2,
                               up_city    IN VARCHAR2,
                               up_country IN VARCHAR2) IS
  BEGIN
    UPDATE library_db_apeilk_address_tab
    SET
      num=up_num_, street=up_street, city=up_city, country=up_country
    WHERE address_id=up_id_;
  END lib_db_apeilk_address_update_;
