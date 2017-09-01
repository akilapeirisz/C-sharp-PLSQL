CREATE OR REPLACE PROCEDURE lib_db_apeilk_address_delete_(up_id_ IN NUMBER) IS
  BEGIN
    DELETE FROM library_db_apeilk_address_tab
    WHERE address_id=up_id_;
  END lib_db_apeilk_address_delete_;
