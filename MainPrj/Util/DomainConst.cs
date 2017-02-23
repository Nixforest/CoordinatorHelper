using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainPrj.Util
{
    public class DomainConst {
        // MARK: -----API request define-----
        /** Autocomplete user */
        public static String PATH_SITE_AUTOCOMPLETE_USER       = "site/autocompleteUser";
        /** Confirm notify */
        public static String PATH_SITE_CONFIRM_NOTIFY          = "site/confirmNotify";
        /** Issue close */
        public static String PATH_SITE_ISSUE_CLOSE             = "site/issueClose";
        /** Issue create */
        public static String PATH_SITE_ISSUE_CREATE            = "site/issueCreate";
        /** Issue list */
        public static String PATH_SITE_ISSUE_LIST              = "site/issueList";
        /** Issue Reopen */
        public static String PATH_SITE_ISSUE_REOPEN            = "site/issueReopen";
        /** Issue Reply */
        public static String PATH_SITE_ISSUE_REPLY             = "site/issueReply";
        /** Issue View */
        public static String PATH_SITE_ISSUE_VIEW              = "site/issueView";
        /** Login page */
        public static String PATH_SITE_LOGIN                   = "site/login";
        /** Logout page */
        public static String PATH_SITE_LOGOUT                  = "site/logout";
        /** News list */
        public static String PATH_SITE_NEWS_LIST               = "site/newsList";
        /** News view */
        public static String PATH_SITE_NEWS_VIEW               = "site/newsView";
        /** Notify count */
        public static String PATH_SITE_NOTIFY_COUNT            = "site/notifyCount";
        /** Notify list */
        public static String PATH_SITE_NOTIFY_LIST             = "site/notifyList";
        /** Notify view */
        public static String PATH_SITE_NOTIFY_VIEW             = "site/notifyView";
        /** Order create */
        public static String PATH_SITE_ORDER_CREATE            = "site/orderCreate";
        /** Order create data label */
        public static String PATH_SITE_ORDER_CREATE_DATA_LABEL = "site/orderCreateDataLabel";
        /** Order list */
        public static String PATH_SITE_ORDER_LIST              = "site/orderList";
        /** Sign up */
        public static String PATH_SITE_SIGN_UP                 = "site/signup";
        /** Sign up data label */
        public static String PATH_SITE_SIGN_UP_DATA_LABEL      = "site/signupDataLabel";
        /** Sign up get District */
        public static String PATH_SITE_SIGN_UP_GET_DISTRICT    = "site/signupGetDistrict";
        /** Sign up get Ward */
        public static String PATH_SITE_SIGN_UP_GET_WARD        = "site/signupGetWard";
        /** Update config */
        public static String PATH_SITE_UPDATE_CONFIG           = "site/updateConfig";
        /** Uphold create */
        public static String PATH_SITE_UPHOLD_CREATE           = "site/upholdCreate";
        /** Uphold list */
        public static String PATH_SITE_UPHOLD_LIST             = "site/upholdList";
        /** Uphold reply */
        public static String PATH_SITE_UPHOLD_REPLY            = "site/upholdReply";
        /** Uphold view */
        public static String PATH_SITE_UPHOLD_VIEW             = "site/upholdView";
        /** Uphold Customer rating */
        public static String PATH_SITE_UPHOLD_CUSTOMER_RATING  = "site/upholdCustomerRating";
        /** Change password */
        public static String PATH_USER_CHANGE_PASS             = "user/changePass";
        /** User profile */
        public static String PATH_USER_PROFILE                 = "user/profile";
        /** Customer register */
        public static String PATH_CUSTOMER_REGISTER            = "customer/register";
        /** Customer register confirm */
        public static String PATH_CUSTOMER_REGISTER_CONFIRM    = "customer/registerConfirm";
    
        // MARK: -----List of keys-----
        /** Token */
        public static String KEY_TOKEN                         = "token";
        /** Keyword */
        public static String KEY_KEYWORD                       = "keyword";
        /** Q */
        public static String KEY_Q                             = "q";
        /** Notify Id */
        public static String KEY_NOTIFY_ID                     = "notify_id";
        /** Type */
        public static String KEY_TYPE                          = "type";
        /** Object Id */
        public static String KEY_OBJECT_ID                     = "obj_id";
        /** Issue Id */
        public static String KEY_ISSUE_ID                      = "issue_id";
        /** Customer Id */
        public static String KEY_CUSTOMER_ID                   = "customer_id";
        /** Customer Name */
        public static String KEY_CUSTOMER_NAME                 = "customer_name";
        /** Customer Address */
        public static String KEY_CUSTOMER_ADDRESS              = "customer_address";
        /** Customer Phone */
        public static String KEY_CUSTOMER_PHONE                = "customer_phone";
        /** Customer contact */
        public static String KEY_CUSTOMER_CONTACT              = "customer_contact";
        /** Title */
        public static String KEY_TITLE                         = "title";
        /** Message */
        public static String KEY_MESSAGE                       = "message";
        /** Problem */
        public static String KEY_PROBLEM                       = "problem";
        /** Page */
        public static String KEY_PAGE                          = "page";
        /** Chief monitor id */
        public static String KEY_CHIEF_MONITOR_ID              = "chief_monitor_id";
        /** Monitor agent id */
        public static String KEY_MONITOR_AGENT_ID              = "monitor_agent_id";
        /** Accounting id */
        public static String KEY_ACCOUNTING_ID                 = "accounting_id";
        /** Username */
        public static String KEY_USERNAME                      = "username";
        /** Password */
        public static String KEY_PASSWORD                      = "password";
        /** GCM device token */
        public static String KEY_GCM_DEVICE_TOKEN              = "gcm_device_token";
        /** APNS device token */
        public static String KEY_APNS_DEVICE_TOKEN             = "apns_device_token";
        /** News Id */
        public static String KEY_NEWS_ID                       = "news_id";
        /** Device phone */
        public static String KEY_DEVICE_PHONE                  = "device_phone";
        /** Id */
        public static String KEY_ID                            = "id";
        /** Note Customer */
        public static String KEY_NOTE_CUSTOMER                 = "note_customer";
        /** qty_12 */
        public static String KEY_QTY_12                        = "qty_12";
        /** qty_50 */
        public static String KEY_QTY_50                        = "qty_50";
        /** qty_12_list */
        public static String KEY_QTY_12_LIST                   = "qty_12_list";
        /** qty_50_list */
        public static String KEY_QTY_50_LIST                   = "qty_50_list";
        /** Phone */
        public static String KEY_PHONE                         = "phone";
        /** Password */
        public static String KEY_PASSWORD_CONFIRM              = "password_confirm";
        /** First name */
        public static String KEY_FIRST_NAME                    = "first_name";
        /** Province Id */
        public static String KEY_PROVINCE_ID                   = "province_id";
        /** District Id */
        public static String KEY_DISTRICT_ID                   = "district_id";
        /** Ward Id */
        public static String KEY_WARD_ID                       = "ward_id";
        /** Street id */
        public static String KEY_STREET_ID                     = "street_id";
        /** Street */
        public static String KEY_STREET                        = "street";
        /** House Number */
        public static String KEY_HOUSE_NUMBER                  = "house_numbers";
        /** Sign up code */
        public static String KEY_SIGN_UP_CODE                  = "signup_code";
        /** Employee Id */
        public static String KEY_EMPLOYEE_ID                   = "employee_id";
        /** Employee Name */
        public static String KEY_EMPLOYEE_NAME                 = "employee_name";
        /** Employee phone */
        public static String KEY_EMPLOYEE_PHONE                = "employee_phone";
        /** Employee code */
        public static String KEY_EMPLOYEE_CODE                 = "employee_code";
        /** Employee image */
        public static String KEY_EMPLOYEE_IMG                  = "employee_image";
        /** Uphold type */
        public static String KEY_UPHOLD_TYPE                   = "type_uphold";
        /** Uphold type */
        public static String KEY_UPHOLD_TYPE_IDX               = "uphold_type";
        /** Content */
        public static String KEY_CONTENT                       = "content";
        /** Contact person */
        public static String KEY_CONTACT_PERSON                = "contact_person";
        /** Contact telephone number */
        public static String KEY_CONTACT_TEL                   = "contact_tel";
        /** Status */
        public static String KEY_STATUS                        = "status";
        /** Status number */
        public static String KEY_STATUS_NUMBER                 = "status_number";
        /** Uphold Id */
        public static String KEY_UPHOLD_ID                     = "uphold_id";
        /** Hours handle */
        public static String KEY_HOURS_HANDLE                  = "hours_handle";
        /** Contact phone */
        public static String KEY_CONTACT_PHONE                 = "contact_phone";
        /** Note */
        public static String KEY_NOTE                          = "note";
        /** Report wrong */
        public static String KEY_REPORT_WRONG                  = "report_wrong";
        /** Note internal */
        public static String KEY_NOTE_INTERNAL                 = "note_internal";
        /** Reply Id */
        public static String KEY_REPLY_ID                      = "reply_id";
        /** Old password */
        public static String KEY_OLD_PASSWORD                  = "old_password";
        /** New password */
        public static String KEY_NEW_PASSWORD                  = "new_password";
        /** New password confirm */
        public static String KEY_NEW_PASSWORD_CONFIRM          = "new_password_confirm";
        /** Code */
        public static String KEY_CODE                          = "code";
        /** Record */
        public static String KEY_RECORD                        = "record";
        /** Notify count text */
        public static String KEY_NOTIFY_COUNT_TEXT             = "NotifyCountText";
        /** Issue create */
        public static String KEY_ISSUE_CREATE                  = "issue_create";
        /** Total page */
        public static String KEY_TOTAL_PAGE                    = "total_page";
        /** Total quantity */
        public static String KEY_TOTAL_QTY                     = "total_qty";
        /** Promotion amount */
        public static String KEY_PROMOTION_AMOUNT              = "promotion_amount";
        /** Discount amount */
        public static String KEY_DISCOUNT_AMOUNT               = "discount_amount";
        /** Total */
        public static String KEY_TOTAL                         = "total";
        /** LIST_CHIEF_MONITOR */
        public static String KEY_LIST_CHIEF_MONITOR            = "LIST_CHIEF_MONITOR";
        /** LIST_MONITOR_AGENT */
        public static String KEY_LIST_MONITOR_AGENT            = "LIST_MONITOR_AGENT";
        /** LIST_ACCOUNTING */
        public static String KEY_LIST_ACCOUNTING               = "LIST_ACCOUNTING";
        /** Model issue */
        public static String KEY_MODEL_ISSUE                   = "model_issue";
        /** Menu */
        public static String KEY_MENU                          = "menu";
        /** Data uphold */
        public static String KEY_DATA_UPHOLD                   = "data_uphold";
        /** Maximum upload size */
        public static String KEY_MAX_UPLOAD                    = "max_upload";
        /** Data issue */
        public static String KEY_DATA_ISSUE                    = "data_issue";
        /** Role id */
        public static String KEY_ROLE_ID                       = "role_id";
        /** User id */
        public static String KEY_USER_ID                       = "user_id";
        /** User id executive */
        public static String KEY_USER_ID_EXECUTIVE             = "user_id_executive";
        /** User information */
        public static String KEY_USER_INFO                     = "user_info";
        /** Check menu */
        public static String KEY_CHECK_MENU                    = "check_menu";
        /** Province list */
        public static String KEY_PROVINCE_LIST                 = "province_list";
        /** District list */
        public static String KEY_DISTRICT_LIST                 = "district_list";
        /** Ward list */
        public static String KEY_WARD_LIST                     = "ward_list";
        /** Detail id */
        public static String KEY_DETAIL_ID                     = "detail_id";
        /** Model uphold */
        public static String KEY_MODEL_UPHOLD                  = "model_uphold";
        /** Address */
        public static String KEY_ADDRESS                       = "address";
        /** Address */
        public static String KEY_GOOGLE_ADDRESS                = "google_address";
        /** Image avatar */
        public static String KEY_IMG_AVATAR                    = "image_avatar";
        /** Notify type */
        public static String KEY_NOTIFY_TYPE                   = "notify_type";
        /** Request type */
        public static String KEY_REQUEST_TYPE                  = "request_by";
        /** Request type */
        public static String KEY_RATING_STATUS                 = "rating_status";
        /** Request type */
        public static String KEY_RATING_TYPE                   = "rating_type";
        /** Request type */
        public static String KEY_RATING_NOTE                   = "rating_note";
        /** Other information */
        public static String KEY_OTHER_INFO                    = "OtherInfo";
        /** Uphold last id */
        public static String KEY_UPHOLD_ID_LASTEST             = "uphold_id_lastest";
        /** Need change pass */
        public static String KEY_NEED_CHANGE_PASS              = "need_change_pass";
        /** Need update app */
        public static String KEY_NEED_UPDATE_APP               = "need_update_app";
        /** Detail reply id */
        public static String KEY_DETAIL_REPLY_ID               = "detail_reply_id";
        /** Uphold create */
        public static String KEY_UPHOLD_CREATE                 = "uphold_create";
        /** Role name */
        public static String KEY_ROLE_NAME                     = "role_name";
        /** List streets */
        public static String KEY_LIST_STREET                   = "list_street";
        /** List agents */
        public static String KEY_LIST_AGENT                    = "list_agent";
        /** List hgd type */
        public static String KEY_LIST_HGD_TYPE                 = "list_hgd_type";
        /** List hgd_invest */
        public static String KEY_LIST_HGD_INVEST               = "list_hgd_invest";
        /** Name */
        public static String KEY_NAME                          = "name";
        /** Data */
        public static String KEY_DATA                          = "data";
        /** Key transaction id */
        public static String KEY_TRANSACTION_ID                = "transaction_id";
        /** Key transaction key */
        public static String KEY_TRANSACTION_KEY               = "transaction_key";
        /** Key transaction type */
        public static String KEY_TRANSACTION_TYPE              = "transaction_type";
        /** Grand total */
        public static String KEY_GRAND_TOTAL                   = "grand_total";
        /** Setting key: is login */
        public static String KEY_SETTING_IS_LOGGING            = "gasservice.isLogin";
        /** Setting key: user token */
        public static String KEY_SETTING_USER_TOKEN            = "gasservice.user.token";
        /** Setting key: training mode */
        public static String KEY_SETTING_TRAINING_MODE         = "gasservice.trainningMode";
        /** Setting key: Transaction id */
        public static String KEY_SETTING_TRANSACTION_ID        = "gasservice.transaction.id";
        /** Setting key: Transaction key */
        public static String KEY_SETTING_TRANSACTION_KEY       = "gasservice.transaction.key";
        /** Setting key: Temp token */
        public static String KEY_SETTING_TEMP_TOKEN            = "gasservice.temp.token";
        /** Setting key: Debug color */
        public static String KEY_SETTING_DEBUG_COLOR           = "gasservice.debug.color";
        /** Setting key: Debug toast */
        public static String KEY_SETTING_DEBUG_TOAST           = "gasservice.debug.toast";
        /** Setting key: Debug zoom */
        public static String KEY_SETTING_DEBUG_ZOOM            = "gasservice.debug.zoom";
        /** Setting key: Debug Is Gas service */
        public static String KEY_SETTING_DEBUG_IS_GAS_SERVICE  = "gasservice.debug.isGasService";
        /** Setting key: Debug Is Show number picker */
        public static String KEY_SETTING_DEBUG_IS_SHOW_NUM_PICKER  = "isShowNumPicker";
        /** Setting key: Material type id */
        public static String KEY_MATERIALS_TYPE_ID             = "materials_type_id";
        /** Setting key: Material id */
        public static String KEY_MATERIALS_ID                  = "materials_id";
        /** Setting key: Material name */
        public static String KEY_MATERIALS_NAME                = "materials_name";
        /** Setting key: Material short name */
        public static String KEY_MATERIALS_NAME_SHORT          = "materials_name_short";
        /** Setting key: Material price */
        public static String KEY_MATERIALS_PRICE               = "material_price";
        /** Setting key: Price */
        public static String KEY_PRICE                         = "price";
        /** Setting key: Quantity */
        public static String KEY_QUANTITY                      = "qty";
        /** Setting key: Real quantity */
        public static String KEY_QUANTITY_REAL                 = "qty_real";
        /** Setting key: Serial */
        public static String KEY_SERI                          = "seri";
        /** Setting key: KEY_KG_EMPTY */
        public static String KEY_KG_EMPTY                      = "kg_empty";
        /** Setting key: KEY_KG_HAS_GAS */
        public static String KEY_KG_HAS_GAS                    = "kg_has_gas";
        /** Setting key: Amount */
        public static String KEY_AMOUNT                        = "amount";
        /** Setting key: Material image */
        public static String KEY_MATERIAL_IMAGE                = "material_image";
        /** Setting key: Email */
        public static String KEY_EMAIL                         = "email";
        /** Setting key: Agent */
        public static String KEY_AGENT                         = "agent";
        /** Setting key: Agent id */
        public static String KEY_AGENT_ID                      = "agent_id";
        /** Setting key: Agent name */
        public static String KEY_AGENT_NAME                    = "agent_name";
        /** Setting key: Agent phone */
        public static String KEY_AGENT_PHONE                   = "agent_phone";
        /** Setting key: Agent cell phone */
        public static String KEY_AGENT_CELL_PHONE              = "agent_cell_phone";
        /** Setting key: Agent phone support */
        public static String KEY_AGENT_PHONE_SUPPORT           = "agent_phone_support";
        /** Setting key: Agent address */
        public static String KEY_AGENT_ADDRESS                 = "agent_address";
        /** Setting key: Agent latitude */
        public static String KEY_AGENT_LAT                     = "agent_latitude";
        /** Setting key: Agent longitude */
        public static String KEY_AGENT_LONG                    = "agent_longitude";
        /** Setting key: Information of agent */
        public static String KEY_INFO_AGENT                    = "info_agent";
        /** Setting key: Information of gas */
        public static String KEY_INFO_GAS                      = "info_gas";
        /** Setting key: Information of promotion */
        public static String KEY_INFO_PROMOTION                = "info_promotion";
        /** Setting key: Distance 1 */
        public static String KEY_DISTANCE_1                    = "distance_1";
        /** Setting key: Distance 2 */
        public static String KEY_DISTANCE_2                    = "distance_2";
        /** Setting key: Allow update */
        public static String KEY_ALLOW_UPDATE                  = "allow_update";
        /** Setting key: Order type */
        public static String KEY_ORDER_TYPE                    = "order_type";
        /** Setting key: Type amount */
        public static String KEY_TYPE_AMOUNT                   = "type_amount";
        /** Setting key: Amount discount */
        public static String KEY_AMOUNT_DISCOUNT               = "amount_discount";
        /** Setting key: Discount type */
        public static String KEY_DISCOUNT_TYPE                 = "discount_type";
        /** Setting key: Status cancel */
        public static String KEY_STATUS_CANCEL                 = "status_cancel";
        /** Setting key: Order detail */
        public static String KEY_ORDER_DETAIL                  = "order_detail";
        /** Setting key: Customer info */
        public static String KEY_CUSTOMER_INFO                 = "customer_info";
        /** Setting key: Boss name */
        public static String KEY_BOSS_NAME                     = "boss_name";
        /** Setting key: Boss phone */
        public static String KEY_BOSS_PHONE                    = "boss_phone";
        /** Setting key: Manager name */
        public static String KEY_MANAGER_NAME                  = "manage_name";
        /** Setting key: Manager phone */
        public static String KEY_MANAGER_PHONE                 = "manage_phone";
        /** Setting key: Technical name */
        public static String KEY_TECHNICAL_NAME                = "technical_name";
        /** Setting key: Technical phone */
        public static String KEY_TECHNICAL_PHONE               = "technical_phone";
    
        /** Key total record */
        public static String KEY_TOTAL_RECORD                  = "total_record";
        /** Code no */
        public static String KEY_CODE_NO                       = "code_no";
        /** Level type */
        public static String KEY_LEVEL_TYPE                    = "level_type";
        /** Created date */
        public static String KEY_CREATED_DATE                  = "created_date";
        /** Created byte */
        public static String KEY_CREATED_BY                    = "created_by";
        /** Sale name */
        public static String KEY_SALE_NAME                     = "sale_name";
        /** Schedule month */
        public static String KEY_SCHEDULE_MONTH                = "schedule_month";
        /** Last reply message */
        public static String KEY_LAST_REPLY_MESSAGE            = "last_reply_message";
        /** Schedule Type */
        public static String KEY_SCHEDULE_TYPE                 = "schedule_type";
        /** Uid login */
        public static String KEY_UID_LOGIN                     = "uid_login";
        /** Date time handle */
        public static String KEY_DATE_TIME_HANDLE              = "date_time_handle";
        /** Reply item */
        public static String KEY_REPLY_ITEM                    = "reply_item";
        /** Image thumb */
        public static String KEY_IMG_THUMB                     = "thumb";
        /** Image large */
        public static String KEY_IMG_LARGE                     = "large";
        /** Image list */
        public static String KEY_IMAGES                        = "images";
        /** Latitude */
        public static String KEY_LATITUDE                      = "latitude";
        /** Version code */
        public static String KEY_VERSION_CODE                  = "version_code";
        /** Longitude */
        public static String KEY_LONGITUDE                     = "longitude";
        /** Uphold list */
        public static String KEY_UPHOLD_LIST                   = "uphold_list";
        /** Uphold rating */
        public static String KEY_UPHOLD_RATING                 = "uphold_rating";
        /** Version code */
        public static String KEY_APP_VERSION_CODE              = "app_version_code";
        /** Confirm code */
        public static String KEY_CONFIRM_CODE                  = "confirm_code";
        /** show_nhan_giao_hang */
        public static String KEY_SHOW_NHAN_GH                  = "show_nhan_giao_hang";
        /** show_huy_giao_hang */
        public static String KEY_SHOW_HUY_GH                   = "show_huy_giao_hang";
        /** Transaction History Id */
        public static String KEY_TRANSACTION_HISTORY_ID        = "transaction_history_id";
        /** Call center uphold */
        public static String KEY_CALL_CENTER_UPHOLD            = "call_center_uphold";
        /** Hotline */
        public static String KEY_HOTLINE                       = "hotline";
        /** Flag gas 24h */
        public static String KEY_FLAG_GAS_24H                  = "app_type";
        /** Key text of order type */
        public static String KEY_ORDER_TYPE_TEXT               = "order_type_text";
        /** Key amount of order type */
        public static String KEY_ORDER_TYPE_AMOUNT             = "order_type_amount";
        /** Key amount of bu vo */
        public static String KEY_AMOUNT_BU_VO                  = "amount_bu_vo";
        /** Key expiration date */
        public static String KEY_EXPIRY_DATE                   = "expiry_date";
        /** Key b50 kg */
        public static String KEY_B50                           = "b50";
        /** Key b45 kg */
        public static String KEY_B45                           = "b45";
        /** Key b12 kg */
        public static String KEY_B12                           = "b12";
        /** Key b6 kg */
        public static String KEY_B6                            = "b6";
        /** Key Unit */
        public static String KEY_UNIT                          = "unit";
        /** Key Delivery date */
        public static String KEY_DATE_DELIVERY                 = "date_delivery";
        /** Key Total gas */
        public static String KEY_TOTAL_GAS                     = "total_gas";
        /** Key Total gas du */
        public static String KEY_TOTAL_GAS_DU                  = "total_gas_du";
        /** Key note of employee */
        public static String KEY_NOTE_EMPLOYEE                 = "note_employee";
        /** Key Name of gas */
        public static String KEY_NAME_GAS                      = "name_gas";
        /** Key name of driver */
        public static String KEY_NAME_DRIVER                   = "name_driver";
        /** Key name of car */
        public static String KEY_NAME_CAR                      = "name_car";
        /** Key name of maintain employee */
        public static String KEY_NAME_EMPLOYEE_MAINTAIN        = "name_employee_maintain";
        /** Key Cylinder information */
        public static String KEY_INFO_CYLINDER                 = "info_vo";
        /** Key Order id */
        public static String KEY_ORDER_ID                      = "order_id";
    
        // MARK: -----Specified constant-----
        /** File parameter: file_name[ + ] */
        public static String FILE_PARAM_FILE_NAME              = "file_name[";
        public static String FILE_PARAM_FILE_NAME_CLOSE        = "]";
        /** Character encoding: UTF-8 */
        public static String CHARACTER_ENCODING_UTF8           = "UTF-8";
        /** Http request header: Content-Type */
        public static String HTTP_REQ_HEADER                   = "Content-Type";
        /** Http request header: application */
        public static String HTTP_REQ_HEADER_CONTENT           = "application/x-www-form-urlencoded";
        /** Specified constant */
        public static String MSG_PRESS_OK                      = "Press OK";
        /** Specified constant */
        public static String MSG_PRESS_REOPEN                  = "Press reopen";
        /** Specified constant */
        public static String MSG_DEVICE_NOT_SUPPORT            = "This device is not supported.";
        /** Specified constant */
        public static String MSG_NOT_RECEIVE_TOKEN             = "Không thể nhận được device token!";
        /** Specified constant */
        public static String MSG_RECEIVE_TOKEN                 = "Đã nhận được device token!!";
        /** Request method: POST */
        public static int REQUEST_POST                          = 1;
        /** Request method: GET */
        public static int REQUEST_GET                           = 2;
        /** Request method: PUT */
        public static int REQUEST_PUT                           = 3;
        /** Request method: DELETE */
        public static int REQUEST_DELETE                        = 4;
        /** Certificate exception */
        public static String CERTIFICATE_NOT_VALID_OR_TRUSTED   = "Certificate not valid or trusted.";
        /** Http scheme */
        public static String SCHEME_HTTP                        = "http";
        /** Https scheme */
        public static String SCHEME_HTTPS                       = "https";
        /** Port: 80 */
        public static int PORT_80                               = 80;
        /** Port: 443 */
        public static int PORT_443                              = 443;
        /** Application mode: Running */
        public static int MODE_RUNNING                          = 0;
        /** Application mode: Training */
        public static int MODE_TRAINING                         = 1;
        /** Issue type: open */
        public static int TYPE_OPEN                             = 1;
        /** Issue type: close */
        public static int TYPE_CLOSE                            = 2;
        /** News type: new */
        public static int TYPE_NEW                              = 1;
        /** News type: view */
        public static int TYPE_VIEW                             = 2;
        /** Google play service resolution request */
        public static int PLAY_SERVICES_RESOLUTION_REQUEST      = 9000;
        /** Maximum of click on Logo to show hidden Activity */
        public static int MAX_CLICK_NUMBER                      = 7;
        /** Result load image */
        public static int RESULT_LOAD_IMG                       = 1000;
        /** Limit number of image can select 1 time */
        public static int MAX_SELECTED_PICTURE                  = 6;
        /** Touch image state: None */
        public static int TOUCH_IMG_NONE                        = 0;
        /** Touch image state: Dragging */
        public static int TOUCH_IMG_DRAG                        = 1;
        /** Touch image state: Zoom */
        public static int TOUCH_IMG_ZOOM                        = 2;
        /** Touch image state: Click */
        public static int TOUCH_IMG_CLICK                       = 3;
        /** Auto search interval */
        public static int SEARCH_INTERVAL                       = 1000;
        /** Minimum number of characters begin search */
        public static int SEARCH_MIN_LENGTH                     = 5;
        /** Pattern to remove accent */
        public static String PATTERN_REMOVE_ACCENT             = "\\p{InCombiningDiacriticalMarks}+";
    
        /** Transaction type: NORMAL */
        public static String TRANSACTION_TYPE_NORMAL           = "1";
    
        /** Uphold type: Periodically */
        public static String UPHOLD_TYPE_PERIODICALLY          = "1";
        /** Uphold type: Trouble */
        public static String UPHOLD_TYPE_TROUBLE               = "2";
        /** Uphold type: Periodically */
        public static int TYPE_PERIODICALLY                     = 1;
        /** Uphold type: Trouble */
        public static int TYPE_TROUBLE                          = 2;
        /** App type flag: Gas 24h */
        public static String APP_TYPE_FLAG_GAS_24H             = "1";
        /** App type flag: Gas Service */
        public static String APP_TYPE_FLAG_GAS_SERVICE         = "0";
    
        /** Order status: New */
        public static String ORDER_STATUS_NEW                  = "1";
        /** Order status: New */
        public static String ORDER_STATUS_PROCESSING           = "3";
        /** Order status: Complete */
        public static String ORDER_STATUS_COMPLETE             = "4";
        /** Order status: Complete */
        public static String ORDER_STATUS_CANCEL               = "5";
        /** Uphold status: Complete */
        public static String UPHOLD_STATUS_COMPLETE            = "3";
        /** Uphold status: New */
        public static String UPHOLD_STATUS_NEW                 = "1";
        /** Uphold status: Handling */
        public static String UPHOLD_STATUS_HANDLE              = "2";
        /** Uphold status: Other */
        public static String UPHOLD_TYPE_OTHER                 = "6";
        /** Uphold contact: Other */
        public static String UPHOLD_CONTACT_OTHER              = "4";
        /** Role id: Customer */
        public static String ROLE_CUSTOMER                     = "4";
        /** Role id: Coordinator */
        public static String ROLE_COORDINATOR                  = "17";
        /** Role id: Audit */
        public static String ROLE_AUDIT                        = "54";
        /** Role id: Chief monitor */
        public static String ROLE_CHIEF_MONITOR                = "28";
        /** Role id: Director */
        public static String ROLE_DIRECTOR                     = "19";
        /** Flag change pass: need change */
        public static String NEED_CHANGE_PASS                  = "1";
        /** Flag change pass: no need change */
        public static String NO_NEED_CHANGE_PASS               = "0";
        /** Maximum number of user interaction tapped */
        public static int MAXIMUM_TAPPED                        = 7;
        /** Notify type: View Uphold */
        public static String NOTIFY_VIEW_UPHOLD                = "VIEW_UPHOLD";
        /** Notify type: View Issue */
        public static String NOTIFY_VIEW_ISSUE                 = "VIEW_ISSUE";
        /** Notify type: Uphold alert 10 */
        public static String NOTIFY_UPHOLD_ALERT_10            = "1";
        /** Notify type: Uphold periodically */
        public static String NOTIFY_UPHOLD_PERIODICALLY_1_DAY  = "2";
        /** Notify type: Issue ticket */
        public static String NOTIFY_ISSUE_TICKET               = "3";
        /** Notify type: Uphold create */
        public static String NOTIFY_UPHOLD_CREATE              = "4";
        /** Response status code: Success */
        public static String RESPONSE_STATUS_SUCCESS           = "1";
        /** Response status code: Success */
        public static String RESPONSE_STATUS_FAILED            = "0";
        /** Report wrong */
        public static String REPORT_WRONG                      = "1";
        /** Report right */
        public static String REPORT_RIGHT                      = "0";
        /** Contact type: Boss */
        public static String CONTACT_TYPE_BOSS                 = "1";
        /** Contact type: Manager */
        public static String CONTACT_TYPE_MANAGER              = "2";
        /** Contact type: Technical */
        public static String CONTACT_TYPE_TECHNICAL            = "3";
        /** Rating status: Glad */
        public static String RATING_STATUS_GLAD                = "1";
        /** Rating status: Normal */
        public static String RATING_STATUS_NORMAL              = "2";
        /** Rating status: Sad */
        public static String RATING_STATUS_SAD                 = "3";
        /** Category type: VIP */
        public static String CATEGORY_TYPE_VIP                 = "1";
        /** Category type: GAS */
        public static String CATEGORY_TYPE_GAS                 = "2";
        /** Category type: Utility */
        public static String CATEGORY_TYPE_UTILITY             = "3";
        /** Category type: Order vip */
        public static String CATEGORY_TYPE_ORDER_VIP           = "4";
        /** Category type: Uphold */
        public static String CATEGORY_TYPE_UPHOLD              = "5";
        /** Employee information id: Phone */
        public static String EMPLOYEE_INFO_PHONE_ID            = "1";
        /** Employee information id: Code */
        public static String EMPLOYEE_INFO_CODE_ID             = "2";
        /** Agent information id: Promotion */
        public static String AGENT_PROMOTION_ID                = "1";
        /** Agent information id: Discount */
        public static String AGENT_DISCOUNT_ID                 = "2";
        /** Agent information id: Total money */
        public static String AGENT_TOTAL_MONEY_ID              = "3";
        /** Agent information id: Name */
        public static String AGENT_NAME_ID                     = "4";
        /** Agent information id: Phone */
        public static String AGENT_PHONE_ID                    = "5";
        /** Agent information id: Support */
        public static String AGENT_SUPPORT_ID                  = "6";
        /** Agent information id: Bu vo */
        public static String AGENT_BUVO_ID                     = "7";
        /** Order information id: Order Id */
        public static String ORDER_INFO_ID_ID                  = "8";
        /** Order information id: Order status */
        public static String ORDER_INFO_STATUS_ID              = "9";
        /** Order information id: Order Car number */
        public static String ORDER_INFO_CAR_NUMBER_ID          = "10";
        /** Order information id: Order Payment method */
        public static String ORDER_INFO_PAYMENT_METHOD_ID      = "11";
        /** Order information id: Order Gas money */
        public static String ORDER_INFO_GAS_MONEY_ID           = "12";
        /** Order information id: Order Gas du */
        public static String ORDER_INFO_GAS_DU_ID              = "13";
        /** Order information id: Order Total money */
        public static String ORDER_INFO_TOTAL_MONEY_ID         = "14";
        /** Order information id: Order Address */
        public static String ORDER_INFO_ADDRESS_ID             = "15";
        /** Order information id: Order Phone */
        public static String ORDER_INFO_PHONE_ID               = "16";

        // MARK: New
        /** Key menu item: Promotion list */
        public static String KEY_MENU_PROMOTION_LIST           = "promotion_list";
        /** GAS string */
        public static String GAS_STRING                        = "GAS";
        /** Default value of promote money */
        public const double PROMOTE_MONEY_DEFAULT_VALUE        = 20000.0;
        /** List of agent id using zibo soft card reader */
        public static List<string> AGENT_LIST_ZIBO             = new List<string>
        {
            "1311",		    // Cửa hàng 1
            "1312",		    // Cửa hàng 2
            "1313",		    // Cửa hàng 3
            "30751",		// Cửa hàng Vĩnh Long 1
            "30753",		// Cửa hàng Cần Thơ 1
            //"138544",		// Cửa hàng Cần Thơ 2
            //"262526",		// Cửa Hàng Ô Môn
            "118",		    // Đại lý An Thạnh
            "116",		    // Đại lý Bình Đa
            //"122",		    // Đại lý Bình Tân
            "106",		    // Đại lý Bình Thạnh 1
            "115",		    // Đại lý Dĩ An
            "108",		    // Đại lý Hóc Môn
            "109",		    // Đại lý Lái Thiêu
            "114",		    // Đại lý Long Bình Tân
            "121",		    // Đại lý Ngã Ba Trị An
            "100",		    // Đại lý Quận 2
            "113",		    // Đại lý Quận 3
            "101",		    // Đại lý Quận 4
            "102",		    // Đại lý Quận 7
            "119",			// Đại lý Tân Định
            "126",		    // Đại lý Tân Phú
            "120",		    // Đại lý Tân Sơn
            "110",		    // Đại lý Thủ Dầu Một
            "112",		    // Đại lý Thủ Đức 1
            //"123"		    // Đại lý Trảng Dài
        };
    
    
        /** Money unit: Vietnam dong */
        public static String VIETNAMDONG                       = " VND";
        /** Promote default value */
        public static String PROMOTION_DEFAULT                 = "50,000";
        /** Discount default value */
        public static String DISCOUNT_DEFAULT                  = "20,000";
        /** The other option */
        public static String OPTION_OTHER                      = "Khác";
        public static String LINE_FEED                         = "\n";
        /** Contact spliter */
        public static String CONTACT_SPLITER                   = DomainConst.LINE_FEED;
        /** Address spliter */
        public static String ADDRESS_SPLITER                   = ",";
        /** Phone spliter */
        public static String PHONE_SPLITER                     = "-";
        /** Text spliter */
        public static String TEXT_SPLITER                      = ":";
        /** Phone spliter */
        public static String NUMBER_ZERO_VALUE                 = "0";
        /** Phone spliter */
        public static String NUMBER_ONE_VALUE                  = "1";
        /** Default time value */
        public static String DEFAULT_TIME_VALUE                = "08:00";
        /** Address unknown string */
        public static String ADDRESS_UNKNOWN                   = "Khong ro, ";
        /** Json error: Failed to load */
        public static String JSON_ERR_FAILED_LOAD              = "Failed to load: ";
        /** Json error: Wrong format */
        public static String JSON_ERR_WRONG_FORMAT             = "Json is of wrong format";
    
        /** -----Log message----- */
        /** Log tag: error. */
        public static String LOG_TAG_ERROR                     = "harpy.error";
        /** Log tag: warn. */
        public static String LOG_TAG_WARN                      = "harpy.warn";
        /** Log tag: info. */
        public static String LOG_TAG_INFO                      = "harpy.info";
        /** Log tag: debug. */
        //public static String LOG_TAG_DEBUG = "harpy.debug";
        /** Log message. */
        public static String LOG_MSG_HTTP_ACCESS_FAILED        = "httpAccessPost fail:";
        /** Log message. */
        public static String LOG_MSG_GET_DATA_FROM_URL         = "Get data from URL: ";
    
        /** Blank character */
        public static String BLANK                             = "";
        /** Space string */
        public static String SPACE_STR                         = " ";
        /** Server URL (Training mode) */
        public static String SERVER_URL_TRAINING               = "http://android.huongminhgroup.com/api/";
        /** Server URL */
        public static String SERVER_URL                        = "http://spj.daukhimiennam.com/api/";
    
        // MARK -----Define id of fragment-----
        public static String LOGOUT                            = "logout";
        public static String ORDER_LIST                        = "order_list";
        public static String ORDER_VIP_LIST                    = "bomoi_list";
        public static String ORDER_CREATE                      = "order_create";
        public static String UPHOLD_LIST                       = "uphold_list";
        public static String NEWS_LIST                         = "news_list";
        public static String USER_PROFILE                      = "user_profile";
        public static String ISSUE_CREATE                      = "Tạo mới phản ánh";
        public static String HOME                              = "home";
        public static String ISSUE_LIST                        = "issue_list";
        public static String MESSAGE                           = "message";
        public static String CUSTOMER_LIST                     = "customer_list";
        public static String WORKING_REPORT                    = "working_report_list";
        public static String ORDER_TRANSACTION_LIST            = "transaction_list";
        public static String ISSUE_VIEW                        = "Chi tiết phản ánh";
        public static String NEWS_VIEW                         = "Chi tiết tin tức";
        public static String UPHOLD_VIEW                       = "Chi tiết bảo trì";
        public static String ISSUE_REPLY                       = "Trả lời phản ánh";
        public static String UPHOLD_REPLY                      = "Trả lời bảo trì";
        public static String USER_CHANGE_PASS                  = "Đổi mật khẩu";
        public static String UPHOLD_CREATE                     = "Tạo mới bảo trì";
    
        // MARK: -----Controller names-----
        /** Application name */
        public static String APPNAME                                       = "gasservice";
        public static String HARPY_FRAMEWORK_BUNDLE_NAME                   = "com.spj.harpyframework.harpyframework";
        /** Name of RegisterViewController */
        public static String G00_REGISTER_VIEW_CTRL                        = "G00RegisterVC";
        /** Name of G00 home view controller */
        public static String G00_HOME_VIEW_CTRL                            = "G00HomeVC";
        /** Name of G00 login view controller */
        public static String G00_LOGIN_VIEW_CTRL                           = "G00LoginVC";
        /** Name of ConfigurationViewController */
        public static String G00_CONFIGURATION_VIEW_CTRL                   = "G00ConfigurationVC";
        /** Name of G00 information view controller */
        public static String G00_INFORMATION_VIEW_CTRL                     = "G00InfomationVC";
        /** Name of AccountViewController */
        public static String G00_ACCOUNT_VIEW_CTRL                         = "G00AccountVC";
        /** Name of Uphold List View Controller */
        public static String G01_F00_S01_VIEW_CTRL                         = "G01F00S01VC";
        /** Name of Uphold detail employee view controller */
        public static String G01_F00_S02_VIEW_CTRL                         = "G01F00S02VC";
        /** Name of Uphold detail customer view controller */
        public static String G01_F00_S03_VIEW_CTRL                         = "G01F00S03VC";
        /** Name of UpholdListViewController */
        public static String PERIOD_UPHOLDDETAIL_CUSTOMER_VIEW_CTRL        = "PeriodUpholdDetailCustomerViewController";
        /** Name of ReplyUpholdViewController */
        public static String REPLY_UPHOLD_VIEW_CTRL                        = "ReplyUpholdViewController";
        /** Name of Uphold detail employee information view */
        public static String G01_F00_S02_INFO_VIEW                         = "G01F00S02InfoView";
    
        /** Name of G01F02 create uphold reply view controller */
        public static String G01_F02_VIEW_CTRL                             = "G01F02VC";
        /** Name of G01F03 uphold rating view controller */
        public static String G01_F03_VIEW_CTRL                             = "G01F03VC";
        /** Name of G04F00 Order list view controller */
        public static String G04_F00_S01_VIEW_CTRL                         = "G04F00S01VC";
        /** Name of G04F02 Promotions list view controller */
        public static String G04_F02_S01_VIEW_CTRL                         = "G04F02S01VC";
        /** Name of G05F00 Order list view controller */
        public static String G05_F00_S01_VIEW_CTRL                         = "G05F00S01VC";
    
        /** Name of ChangePasswordViewController */
        public static String G00_CHANGE_PASS_VIEW_CTRL                     = "G00ChangePassVC";
        /** Name of G01F01VC */
        public static String G01_F01_VIEW_CTRL                             = "G01F01VC";
        /** Name of Internal view controller */
        public static String INTERNAL_VIEW_CTRL                            = "InternalViewController";
        /** Name of zoomIMGViewController */
        public static String ZOOM_IMAGE_VIEW_CTRL                          = "zoomIMGViewController";
        /** Home table view cell */
        public static String G00_HOME_CELL                                 = "G00HomeCell";
        /** Period table view cell */
        public static String G01_F00_S01_PERIOD_CELL                       = "TableCellUpholdType";
        /** Problem table view cell */
        public static String G01_F00_S01_PROBLEM_CELL                      = "TableCellUpholdType";
        /** Search bar table view cell */
        public static String SEARCH_BAR_TABLE_VIEW_CELL                    = "SearchBarTableViewCell";
        /** Configuration table view cell */
        public static String CONFIGURATION_TABLE_VIEW_CELL                 = "ConfigurationTableViewCell";
        /** Configuration table view cell */
        public static String ORDER_DETAIL_TABLE_VIEW_CELL                  = "OrderDetailTableViewCell";
        /** Material table view cell */
        public static String MATERIAL_TABLE_VIEW_CELL                      = "MaterialTableViewCell";
        /** Uphold detail employee history table view cell */
        public static String UPHOLD_DETAIL_EMPLOYEE_HISTORY_TABLE_VIEW_CELL = "G01F00S02HistoryCell";
        /** Collection Image view cell */
        public static String COLLECTION_IMAGE_VIEW_CELL                    = "CollectionImageViewCell";
        /** Material selection view cell */
        public static String MATERIAL_SELECTION_VIEW_CELL                  = "MaterialSelectionCell";
        /** Table view cell order type */
        public static String TABLE_VIEW_CELL_ORDER_TYPE                    = "TableCellOrderType";
        /** Table view cell Promotion */
        public static String PROMOTION_TABLE_VIEW_CELL                     = "PromotionTableViewCell";
    
        /** Pop overmenu identifier */
        public static String POPOVER_MENU_IDENTIFIER                       = "popOverMenu";
        /** G01F02S06 table view cell */
        public static String G01_F02_S06_CELL                              = "ImageTableViewCell";
    
        // MARK: -----Notification name-----
        public static String NOTIFY_NAME_LOGIN_ITEM                        = "loginItemTapped";
        public static String NOTIFY_NAME_LOGOUT_ITEM                       = "logoutItemTapped";
        public static String NOTIFY_NAME_REGISTER_ITEM                     = "registerItemTapped";
        public static String NOTIFY_NAME_GAS_SERVICE_ITEM                  = "gasServiceItemTapped";
        public static String NOTIFY_NAME_ISSUE_ITEM                        = "issueItemTapped";
        public static String NOTIFY_NAME_COFIG_ITEM                        = "configItemTapped";
        public static String NOTIFY_NAME_COFIG_ITEM_ACCOUNTVIEW            = "configItemTappedAccountView";
        public static String NOTIFY_NAME_COFIG_ITEM_UPHOLDLISTVIEW         = "configItemTappedUpholdListView";
        public static String NOTIFY_NAME_COFIG_ITEM_CREATE_UPHOLD          = "configItemTappedCreateUphold";
        public static String NOTIFY_NAME_COFIG_ITEM_UPHOLDDETAILVIEW       = "configItemTappedUpholdDetailView";
        public static String NOTIFY_NAME_COFIG_ITEM_CHANGEPASSVIEW         = "configItemTappedChangePassView";
        public static String NOTIFY_NAME_COFIG_ITEM_REGISTERVIEW           = "configItemTappedRegisterView";
        public static String NOTIFY_NAME_SET_DATA_ACCOUNTVIEW              = "G00AccountVC.setData";
        public static String NOTIFY_NAME_SET_DATA_UPHOLDLIST_VIEW          = "G01F00S01VC.setData";
        public static String NOTIFY_NAME_RELOAD_DATA_UPHOLDLIST_VIEW       = "G01F00S01VC.reloadData";
        public static String NOTIFY_NAME_SHOW_SEARCH_BAR_UPHOLDLIST_VIEW   = "G01F00S01VC.showSearchBarTableView";
        public static String NOTIFY_NAME_SET_DATA_UPHOLD_DETAIL_VIEW       = "UpholdDetailViewController.setData";
        public static String NOTIFY_NAME_COFIG_ITEM_G01F02                 = "G01F2VC.configItemTapped";
        public static String NOTIFY_NAME_SET_DATA_G01F01                   = "G01F1VC.setData";
        public static String NOTIFY_NAME_SET_DATA_G01F02                   = "G01F2VC.setData";
        public static String NOTIFY_NAME_SET_DATA_G01F03                   = "G01F3VC.setData";
        public static String NOTIFY_NAME_SET_DATA_HOMEVIEW                 = "G00HomeVC.setData";
        public static String NOTIFY_NAME_COFIG_ITEM_HOMEVIEW               = "G00HomeVC.configItemTapped";
        public static String NOTIFY_NAME_UPDATE_NOTIFY_HOMEVIEW            = "G00HomeVC.updateNotify";
        public static String NOTIFY_NAME_RELOAD_DATA_UPHOLD_DETAIL_VIEW    = "G01F00S02.reloadData";
    
        // MARK: -----Domain constants-----
        /** Logo image name */
        public static String LOGO_GAS_SERVICE_IMG_NAME             = "gasservice_logo.png";
        public static String LOGO_GAS_24H_IMG_NAME                 = "gas24h_logo.png";
        /** Contact image name */
        public static String CONTACT_IMG_NAME                      = "contact.png";
        /** Next icon image name */
        public static String NEXT_ICON_IMG_NAME                    = "ic_number_next.png";
        /** Back icon image name */
        public static String BACK_ICON_IMG_NAME                    = "ic_number_back.png";
        /** Phone image name */
        public static String PHONE_IMG_NAME                        = "phone-ios.png";
        /** Address image name */
        public static String ADDRESS_IMG_NAME                      = "icon34-user-iso.png";
        /** Menu image name */
        public static String MENU_IMG_NAME                         = "menu.png";
        /** Back image name */
        public static String BACK_IMG_NAME                         = "back.png";
        /** Back image name */
        public static String DELETE_IMG_NAME                       = "delete.png";
        /** Uncheck image name */
        public static String UNCHECK_IMG_NAME                      = "checkbox-unchecked.png";
        /** Checked image name */
        public static String CHECKED_IMG_NAME                      = "checkbox-checked.png";
        /** Login image name */
        public static String LOGIN_MENU_IMG_NAME                   = "login.png";
        /** Logout image name */
        public static String LOGOUT_MENU_IMG_NAME                  = "logoutitem.png";
        /** Register image name */
        public static String REGISTER_MENU_IMG_NAME                = "register.png";
        /** Issue image name */
        public static String ISSUE_MENU_IMG_NAME                   = "issueMenu.png";
        /** Config image name */
        public static String CONFIG_MENU_IMG_NAME                  = "configuration.png";
        /** Training mode image name */
        public static String TRAINING_MODE_IMG_NAME                = "trainingMode.png";
        /** Information image name */
        public static String INFORMATION_IMG_NAME                  = "information";
        /** Order gas image name */
        public static String ORDER_GAS_IMG_NAME                    = "ordergas.png";
        /** Logo of agent image name */
        public static String LOGO_AGENT_GAS_24H_IMG_NAME           = "logo_agent.png";
        /** Logo of agent image name */
        public static String LOGO_AGENT_GAS_SERVICE_IMG_NAME       = "icon10-active.png";
        /** Uphold request image name */
        public static String UPHOLD_REQUEST_IMG_NAME               = "upholdRequest.png";
        /** Uphold list image name */
        public static String UPHOLD_LIST_IMG_NAME                  = "UpHoldList.jpeg";
        /** Service rating image name */
        public static String SERVICE_RATING_IMG_NAME               = "ServiceRating.jpeg";
        /** Account image name */
        public static String ACCOUNT_IMG_NAME                      = "Account.jpeg";
        /** Done image name */
        public static String DONE_IMG_NAME                         = "done.png";
        /** Username image */
        public static String USERNAME_IMG_NAME                     = "icon2.png";
        /** Password image */
        public static String PASSWORD_IMG_NAME                     = "icon3.png";
        /** Login image */
        public static String LOGIN_IMG_NAME                        = "icon4-ios.png";
        /** Confirm image name */
        public static String CONFIRM_IMG_NAME                      = "icon20.png";
        /** Cancel image name */
        public static String CANCEL_IMG_NAME                       = "icon21.png";
        /** Cancel image name */
        public static String ADD_ICON_IMG_NAME                     = "cong.png";
        /** Rating image name */
        public static String RATING_IMG_NAME                       = "icon25.png";
        /** User name image */
        public static String USER_NAME_IMG_NAME                    = "icon32-user-iso.png";
        /** User phone image */
        public static String USER_PHONE_IMG_NAME                   = "icon33-user-iso.png";
        /** Save information image */
        public static String SAVE_INFO_IMG_NAME                    = "icon35-user-ios.png";
        /** Change password image */
        public static String CHANGE_PASS_IMG_NAME                  = "icon36-user-ios.png";
        /** Logout image */
        public static String LOGOUT_IMG_NAME                       = "icon37-user-ios.png";
        /** Old password image */
        public static String OLD_PASS_IMG_NAME                     = "icon38-user-ios.png";
        /** New password image */
        public static String NEW_PASS_IMG_NAME                     = "icon39-doimatkhau-ios.png";
        /** Order icon image */
        public static String ORDER_ICON_IMG_NAME                   = "ic_custom_order_top.png";
        /** Material selection logo image name */
        public static String MATERIAL_SELECTION_IMG_NAME           = "icon12.png";
        /** Promotion icon image name */
        public static String PROMOTION_ICON_IMG_NAME               = "icon13.png";
        /** Money icon image name */
        public static String MONEY_ICON_IMG_NAME                   = "icon16.png";
        /** Money icon image name */
        public static String AGENT_ICON_IMG_NAME                   = "icon17.png";
        /** Money icon image name */
        public static String PHONE_ICON_IMG_NAME                   = "icon18.png";
        /** Money icon image name */
        public static String SUPPORT_ICON_IMG_NAME                 = "icon19.png";
        /** Employee code image name */
        public static String EMPLOYEE_ICON_IMG_NAME                = "icon23.png";
        /** Default material image name */
        public static String DEFAULT_MATERIAL_IMG_NAME             = "icon24.png";
        /** Rating empty image name */
        public static String RATING_EMPTY_IMG_NAME                 = "icon27.png";
        /** Problem icon image name */
        public static String PROBLEM_ICON_IMG_NAME                 = "icon59.png";
        /** Human icon image name */
        public static String HUMAN_ICON_IMG_NAME                   = "icon47.png";
        /** Status icon image name */
        public static String STATUS_ICON_IMG_NAME                  = "icon48.png";
        /** Address icon image name */
        public static String ADDRESS_ICON_IMG_NAME                 = "icon49.png";
        /** Customer feeling image name: Normal */
        public static String CUST_FEELING_NORMAL_IMG_NAME          = "icon52.png";
        /** Customer feeling image name: Glad */
        public static String CUST_FEELING_GLAD_IMG_NAME            = "icon53.png";
        /** Customer feeling image name: Sad */
        public static String CUST_FEELING_SAD_IMG_NAME             = "icon54.png";
        /** Customer icon image name */
        public static String CUSTOMER_ICON_IMG_NAME                = "icon55.png";
        /** Contact icon image name */
        public static String CONTACT_ICON_IMG_NAME                 = "icon58.png";
        /** Problem type icon image name */
        public static String PROBLEM_TYPE_IMG_NAME                 = "icon59.png";
        /** Content icon image name */
        public static String CONTENT_ICON_IMG_NAME                 = "icon60.png";
        /** Content icon image name */
        public static String REPORT_ICON_IMG_NAME                  = "icon62.png";
        /** Content icon image name */
        public static String ORDER_ID_ICON_IMG_NAME                = "icon65.png";
        /** Content icon image name */
        public static String ORDER_STATUS_ICON_IMG_NAME            = "icon66.png";
        /** Content icon image name */
        public static String ORDER_CAR_NUMBER_ICON_IMG_NAME        = "icon67.png";
        /** Content icon image name */
        public static String ORDER_PAYMENT_METHOD_ICON_IMG_NAME    = "icon68.png";
        /** Money icon image name */
        public static String MONEY_ICON_GREY_IMG_NAME              = "icon69.png";
        /** Money icon image name */
        public static String MONEY_ICON_PAPER_IMG_NAME              = "icon70.png";
        /** Order icon image name */
        public static String ORDER_START_ICON_IMG_NAME             = "icon76.png";
        /** Order status new image name */
        public static String ORDER_STATUS_NEW_ICON_IMG_NAME        = "new-icon.png";
        /** Order status process image name */
        public static String ORDER_STATUS_PROCESS_ICON_IMG_NAME    = "icon80.png";
        /** Order status Cancel image name */
        public static String ORDER_STATUS_CANCEL_ICON_IMG_NAME     = "icon81.png";
        /** Type 1 backgroud image name */
        public static String TYPE_1_BKG_IMG_NAME                   = "bg1.jpg";
        /** Menu backgroud body image name */
        public static String MENU_BKG_BODY_IMG_NAME                = "bg_sliding_menu_body.jpg";
        /** Menu backgroud top image name */
        public static String MENU_BKG_TOP_IMG_NAME                 = "bg_sliding_menu_top.jpg";
        /** Menu item Home image name */
        public static String MENU_ITEM_HOME_IMG_NAME               = "ic_menu_home.png";
        /** Menu item Home image name */
        public static String MENU_ITEM_GIFT_IMG_NAME               = "ic_menu_gift.png";
        /** Menu item Profile image name */
        public static String MENU_ITEM_PROFILE_IMG_NAME            = "ic_menu_profile.png";
        /** Menu item Uphold list image name */
        public static String MENU_ITEM_UPHOLD_LIST_IMG_NAME        = "list.png";
        /** Menu item Message image name */
        public static String MENU_ITEM_MSG_IMG_NAME                = "message.png";
        /** Menu item Working report image name */
        public static String MENU_ITEM_WORKING_REPORT_IMG_NAME     = "report.png";
        /** Menu item Order list image name */
        public static String MENU_ITEM_ORDER_LIST_IMG_NAME         = "ic_menu_shoping_cart.png";
        /** Finish status image name */
        public static String FINISH_STATUS_IMG_NAME                = "icon29.png";
        /** Date time icon image name */
        public static String DATETIME_ICON_IMG_NAME                = "icon45.png";
        /** Category image name: VIP */
        public static String CATEGORY_VIP_IMG_NAME                 = "icon9.png";
        /** Category image name: VIP active */
        public static String CATEGORY_VIP_ACTIVE_IMG_NAME          = "icon9-active.png";
        /** Category image name: GAS */
        public static String CATEGORY_GAS_IMG_NAME                 = "icon10.png";
        /** Category image name: Uphold */
        public static String CATEGORY_UPHOLD_IMG_NAME              = "icon77.png";
        /** Category image name: GAS active */
        public static String CATEGORY_GAS_ACTIVE_IMG_NAME          = "icon10-active.png";
        /** Category image name: Utility */
        public static String CATEGORY_UTILITY_IMG_NAME             = "icon11.png";
        /** Category image name: GAS active */
        public static String CATEGORY_UTILITY_ACTIVE_IMG_NAME      = "icon11-active.png";
        /** Center marker image name */
        public static String CENTER_MARKER_IMG_NAME                = "ic_checkpoint.png";
        /** HTTP Post request method */
        public static String HTTP_POST_REQUEST                     = "POST";
    
        // MARK: -----Version code-----
        public static String VERSION_CODE                          = "111";
        public static String VERSION_CODE_NAME                     = "Gas Service 1.1.1 @2016 Southern Petroleum";
        public static String EMAIL                                 = "it@spj.vn";
        public static String WEBSITE                               = "http://daukhimiennam.com";
    
    
        // MARK: -----Public static strings-----
        public static String CONTENT00001 = "Harpy Framework";
        public static String CONTENT00002 = "Chưa chọn khách hàng";
        public static String CONTENT00003 = "Chưa chọn nguyên nhân!";
        public static String CONTENT00004 = "Chưa nhập tiêu đề!";
        public static String CONTENT00005 = "Chưa nhập nội dung!";
        public static String CONTENT00006 = "Bạn chỉ được nhập tối đa %1$d hình!";
        public static String CONTENT00007 = "Vui lòng kiểm tra lại dữ liệu!";
        public static String CONTENT00008 = "OK";
        public static String CONTENT00009 = "Cancel";
        public static String CONTENT00010 = "Bạn chắc chắn muốn close Issue";
        public static String CONTENT00011 = "Bạn chắc chắn muốn Reopen Issue";
        public static String CONTENT00012 = "Mã số:";
        public static String CONTENT00013 = "Khách hàng:";
        public static String CONTENT00014 = "NV kinh doanh:";
        public static String CONTENT00015 = "Địa chỉ:";
        public static String CONTENT00016 = "Tiêu đề:";
        public static String CONTENT00017 = "Người tạo:";
        public static String CONTENT00018 = "Ngày tạo:";
        public static String CONTENT00019 = "Trạng thái:";
        public static String CONTENT00020 = "Nguyên nhân:";
        public static String CONTENT00021 = "Điện thoại:";
        public static String CONTENT00022 = "Người liên hệ:";
        public static String CONTENT00023 = "Tài khoản và mật khẩu không được trống!";
        public static String CONTENT00024 = "(%1$s)";
        public static String CONTENT00025 = "Bạn vui lòng điền đầy đủ thông tin!";
        public static String CONTENT00026 = "Mật khẩu nhập lại không chính xác!";
        public static String CONTENT00027 = "Chưa chọn NV bảo trì!";
        public static String CONTENT00028 = "Chưa chọn loại sự cố!";
        public static String CONTENT00029 = "Chưa nhập người liên hệ!";
        public static String CONTENT00030 = "Chưa nhập số điện thoại!";
        public static String CONTENT00031 = "Nội dung: \n";
        public static String CONTENT00032 = "Liên hệ:";
        public static String CONTENT00033 = "Sự cố:";
        public static String CONTENT00034 = "Mức độ:";
        public static String CONTENT00035 = "Ngày bảo trì:";
        public static String CONTENT00036 = "Lịch bảo trì:";
        public static String CONTENT00037 = "Nhân viên bảo trì:";
        public static String CONTENT00038 = "Số điện thoại:";
        public static String CONTENT00039 = "Báo cáo kết quả: \n";
        public static String CONTENT00040 = "Bảo trì định kỳ";
        public static String CONTENT00041 = "Yêu cầu bảo trì";
        public static String CONTENT00042 = "Thời gian xử lý:";
        public static String CONTENT00043 = "Chưa chọn trạng thái!";
        public static String CONTENT00044 = "Tin nhắn từ Gas Service";
        public static String CONTENT00045 = "Nội dung:";
        public static String CONTENT00046 = "Mất kết nối mạng, vui lòng thử lại!";
        public static String CONTENT00047 = "Có lỗi xảy ra, vui lòng thử lại!";
        public static String CONTENT00048 = "Có lỗi xảy ra";
        public static String CONTENT00049 = "Tài khoản / Số điện thoại";
        public static String CONTENT00050 = "Mật khẩu";
        public static String CONTENT00051 = "Đăng nhập";
        public static String CONTENT00052 = "Đăng ký";
        public static String CONTENT00053 = "Welcome to gas app!";
        public static String CONTENT00054 = "Số điện thoại";
        public static String CONTENT00055 = "Họ và tên";
        public static String CONTENT00056 = "Nhập lại mật khẩu";
        public static String CONTENT00057 = "Số nhà";
        public static String CONTENT00058 = "Tên đường";
        public static String CONTENT00059 = "Title";
        public static String CONTENT00060 = "Tìm kiếm KH, nhập tối thiểu 5 ký tự";
        public static String CONTENT00061 = "Mã khách hàng";
        public static String CONTENT00062 = "Tiêu đề";
        public static String CONTENT00063 = "Nội dung";
        public static String CONTENT00064 = "Thêm hình";
        public static String CONTENT00065 = "Tạo mới";
        public static String CONTENT00066 = "Xoá hình";
        public static String CONTENT00067 = "Open";
        public static String CONTENT00068 = "Close";
        public static String CONTENT00069 = "Không có dữ liệu";
        public static String CONTENT00070 = "Gửi trả lời";
        public static String CONTENT00071 = "Lịch sử trả lời";
        public static String CONTENT00072 = "Thông tin";
        public static String CONTENT00073 = "Đóng lại";
        public static String CONTENT00074 = "Mới";
        public static String CONTENT00075 = "Đã xem";
        public static String CONTENT00076 = "Người liên hệ";
        public static String CONTENT00077 = "Bảo trì sự cố";
        public static String CONTENT00078 = "Bảo trì định kỳ";
        public static String CONTENT00079 = "Tên khách hàng";
        public static String CONTENT00080 = "Báo sai sự cố";
        public static String CONTENT00081 = "Ghi chú";
        public static String CONTENT00082 = "Ghi chú nội bộ";
        public static String CONTENT00083 = "Mật khẩu cũ";
        public static String CONTENT00084 = "Mật khẩu mới";
        public static String CONTENT00085 = "Xác nhận mật khẩu mới";
        public static String CONTENT00086 = "Lưu";
        public static String CONTENT00087 = "Họ tên";
        public static String CONTENT00088 = "Địa chỉ";
        public static String CONTENT00089 = "Đổi mật khẩu";
        public static String CONTENT00090 = "Thoát";
        public static String CONTENT00091 = "Mã";
        public static String CONTENT00092 = "Trạng thái";
        public static String CONTENT00093 = "Nguyên nhân";
        public static String CONTENT00094 = "Nhân viên sale";
        public static String CONTENT00095 = "Người tạo";
        public static String CONTENT00096 = "Ngày tạo";
        public static String CONTENT00097 = "Mở lại";
        public static String CONTENT00098 = "Đánh giá dịch vụ";
        public static String CONTENT00099 = "Danh sách bảo trì";
        public static String CONTENT00100 = "Tài khoản";
        public static String CONTENT00101 = "Chưa chọn hình ảnh";
        public static String CONTENT00102 = "Hiện mật khẩu";
        public static String CONTENT00103 = "Nội dung đánh giá &amp; góp ý";
        public static String CONTENT00104 = "Khách hàng: %1$s";
        public static String CONTENT00105 = "Ngày tạo: $1%s";
        public static String CONTENT00106 = "%1$sID: %2$s";
        public static String CONTENT00107 = "%1$s - %2$s";
        public static String CONTENT00108 = "Gas Service";
        public static String CONTENT00109 = "Số serial bình";
        public static String CONTENT00110 = "Loại định kỳ:";
        public static String CONTENT00111 = "Loại khách hàng:";
        public static String CONTENT00112 = "Vị trí";
        public static String CONTENT00113 = "Số serial bình:";
        public static String CONTENT00114 = "Chưa cập nhật được vị trí hiện tại!";
        public static String CONTENT00115 = "Thương hiệu khách hàng đã dùng";
        public static String CONTENT00116 = "Tên dịch vụ đối thủ";
        public static String CONTENT00117 = "Thông tin thêm: ";
        public static String CONTENT00118 = "Loại điểm: ";
        public static String CONTENT00119 = "Thời gian dự kiến hết gas: ";
        public static String CONTENT00120 = "Thương hiệu đối thủ:";
        public static String CONTENT00121 = "Tên đối thủ:";
        public static String CONTENT00122 = "Tạo Khách Hàng";
        public static String CONTENT00123 = "Điện thoại liên hệ";
        public static String CONTENT00124 = "Version code hiện tại:";
        public static String CONTENT00125 = "Xem thêm";
        public static String CONTENT00126 = "Cập nhật thông tin thành công";
        public static String CONTENT00127 = "Home";
        public static String CONTENT00128 = "Cài đặt";
        public static String CONTENT00129 = "Bảo trì";
        public static String CONTENT00130 = "Đặt gas";
        public static String CONTENT00131 = "Quản lý sự việc";
        public static String CONTENT00132	= "Đăng xuất";
        public static String CONTENT00133	= "Nhập mã xác thực";
        public static String CONTENT00134	= "Một mã xác thực đã được gửi đến số điện thoại của bạn dưới dạng tin nhắn, hãy nhập nó vào ô bên dưới";
        public static String CONTENT00135 = "Mã xác thực";
        public static String CONTENT00136 = "Để sau";
        public static String CONTENT00137 = "Thông tin đăng ký còn thiếu";
        public static String CONTENT00138 = "Chế độ training";
        public static String CONTENT00139 = "Thông tin";
        public static String CONTENT00140	= "vd: 0123456789-0908070605";
        public static String CONTENT00141	= "Cập nhật";
        public static String CONTENT00142	= "Đã có phiên bản mới, vui lòng cập nhật!";
        public static String CONTENT00143 = "Chi tiết bảo trì";
        public static String CONTENT00144 = "NVKD";
        public static String CONTENT00145 = "NV Bảo trì";
        public static String CONTENT00146 = "Liên hệ";
        public static String CONTENT00147 = "Sự cố";
        public static String CONTENT00148 = "Mã số";
        public static String CONTENT00149 = "Tạo trả lời";
        public static String CONTENT00150 = "Ngày xử lý";
        public static String CONTENT00151 = "Nội bộ";
        public static String CONTENT00152 = "Điện thoại";
        public static String CONTENT00153 = "Đánh giá nhân viên bảo trì";
        public static String CONTENT00154 = "Cập nhật khách hàng";
        public static String CONTENT00155 = "Góp ý";
        public static String CONTENT00156 = "Nhân viên bảo trì";
        public static String CONTENT00157 = "Tgian xử lý";
        public static String CONTENT00158 = "Kết quả";
        public static String CONTENT00159 = "Báo cáo";
        public static String CONTENT00160 = "Ngày bảo trì";
        public static String CONTENT00161 = "Lịch bảo trì";
        public static String CONTENT00162 = "Thông báo";
        public static String CONTENT00170 = "Số điện thoại người nhận";
        public static String CONTENT00176 = "Không tìm thấy đại lý quanh vị trí hiện tại!";
        public static String CONTENT00177 = "Loại định kỳ";
        public static String CONTENT00178 = "Tạo mới bảo trì";
        public static String CONTENT00180 = "Gửi";
        public static String CONTENT00181 = "Xin vui lòng chọn Trạng thái sự cố";
        public static String CONTENT00182 = "Xin vui lòng chọn Thời lượng xử lý";
        public static String CONTENT00183 = "Xin vui lòng đánh giá thông tin KH";
        public static String CONTENT00184 = "Khách hàng báo ĐÚNG sự cố";
        public static String CONTENT00185 = "Khách hàng báo SAI sự cố";
        public static String CONTENT00186 = "Trả lời bảo trì";
        public static String CONTENT00187 = "Xin nhập thông tin Người nghiệm thu";
        public static String CONTENT00188 = "Xin nhập thông tin Ghi chú nội bộ";
        public static String CONTENT00189 = "Xin bổ sung Hình ảnh liên quan";
        public static String CONTENT00190 = "Bạn đang gửi thông tin trả lời như bên dưới cho chúng tôi. Xin hãy kiểm tra lại các thông tin cho thật chính xác và nhấn nút Gửi nếu bạn đồng ý.";
        public static String CONTENT00191 = "Khách hàng báo sai sự cố";
        public static String CONTENT00194 = "Thời gian";
        public static String CONTENT00195 = "Nghiệm thu";
        public static String CONTENT00196 = "Lỗi kết nối đến máy chủ";
        public static String CONTENT00197 = "Chức năng đã bị khoá, vui lòng thử lại sau!";
        public static String CONTENT00198 = "Thông tin phiên bản";
        public static String CONTENT00199 = "Email góp ý";
        public static String CONTENT00200 = "Trang chủ";
        public static String CONTENT00201 = "Xin vui lòng chọn Loại sự cố";
        public static String CONTENT00202 = "Huỷ";
        public static String CONTENT00203 = "Sự cố khác";
        public static String CONTENT00204 = "Xin vui lòng chọn Người liên hệ";
        public static String CONTENT00205 = "Bạn đang gửi thông tin sự cố như bên dưới cho chúng tôi. Xin hãy kiểm tra lại các thông tin cho thật chính xác và nhấn nút Gửi nếu bạn đồng ý.";
        public static String CONTENT00206 = "Xin vui lòng đánh giá Mức độ hài lòng";
        public static String CONTENT00207 = "Xin vui lòng đánh giá Nhân viên bảo trì";
        public static String CONTENT00208 = "Nội dung cần đánh giá và góp ý";
        public static String CONTENT00209 = "Xin cảm ơn quý khách hàng đã đánh giá dịch vụ của chúng tôi. Xin hãy kiểm tra lại các thông tin cho thật chính xác và nhấn nút Gửi nếu quý khách hàng đồng ý.";
        public static String CONTENT00210 = "Mức hài lòng";
        public static String CONTENT00212 = "Xem ảnh";
        public static String CONTENT00217 = "Xác nhận";
        public static String CONTENT00218 = "Tổng cộng";
        public static String CONTENT00219 = "Khuyến mãi";
        public static String CONTENT00220 = "Huỷ bỏ";
        public static String CONTENT00222 = "Thêm mã khuyến mại";
        public static String CONTENT00223 = "Xem";
        public static String CONTENT00224 = "Để sau";
        public static String CONTENT00225 = "Bảo trì miễn phí";
        public static String CONTENT00226 = "Gas 24h";
        public static String CONTENT00227 = "Quên mật khẩu?";
        public static String CONTENT00228 = "Tạo tài khoản mới";
        public static String CONTENT00229 = "Lưu thông tin";
        public static String CONTENT00230 = "Xác thực";
        public static String CONTENT00231 = "Đơn hàng";
        public static String CONTENT00232 = "Chi tiết đơn hàng";
        public static String CONTENT00233 = "Nhân viên giao hàng";
        public static String CONTENT00234 = "Camera";
        public static String CONTENT00235 = "Thư viện";
        public static String CONTENT00236 = "Mua hàng";
        public static String CONTENT00237 = "Chọn loại gas";
        public static String CONTENT00238 = "Chọn quà tặng";
        public static String CONTENT00239 = "Chiết khấu";
        public static String CONTENT00240 = "Đại lý";
        public static String CONTENT00241 = "Gọi GAS";
        public static String CONTENT00242 = "Hỗ trợ Khách hàng";
        public static String CONTENT00243 = "Địa chỉ người nhận";
        public static String CONTENT00244 = "Không lấy quà";
        public static String CONTENT00245 = "Mã nhân viên";
        public static String CONTENT00246 = "Bù vỏ:";
        public static String CONTENT00247 = "Khuyến mãi";
        public static String CONTENT00248 = "Hết hạn vào";
        public static String CONTENT00249 = "Nhập mã khuyến mãi";
        public static String CONTENT00250 = "Mã khuyến mãi";
        public static String CONTENT00251 = "Thử lại";
        public static String CONTENT00252 = "Đặt hàng";
        public static String CONTENT00253 = "Thông tin đơn hàng";
        public static String CONTENT00254 = "Loại bình";
        public static String CONTENT00255 = "Số lượng";
        public static String CONTENT00256 = "Quý khách chắc chắn muốn huỷ đơn hàng?";
        public static String CONTENT00257 = "Mã đơn hàng";
        public static String CONTENT00258 = "Số xe";
        public static String CONTENT00259 = "Hình thức thanh toán";
        public static String CONTENT00260 = "Tiền gas";
        public static String CONTENT00261 = "Tiền gas dư";
        public static String CONTENT00262 = "Tổng thanh toán";
        public static String CONTENT00263 = "Thông tin vỏ";
        public static String CONTENT00264 = "Bạn phải chọn vật tư trước";
        public static String CONTENT00265 = "Chọn xe cần điều";
        public static String CONTENT00266 = "Đang gửi yêu cầu tạo đơn hàng";
        public static String CONTENT00267 = "Không rõ";
        public static String CONTENT00268 = "Bảo trì bếp & chăm sóc khách hàng";
        public static String CONTENT00269 = "Cảm ơn quý khách và hẹn gặp lại!";
        public static String CONTENT00270 = "Tên hàng";
        public static String CONTENT00271 = "SL";
        public static String CONTENT00272 = "ĐG";
        public static String CONTENT00273 = "T.Tiền";
        public static String CONTENT00274 = "Quà tặng kèm theo";
        public static String CONTENT00275 = "Tên quà tặng";
        public static String CONTENT00276 = "Tổng hóa đơn";
        public static String CONTENT00277 = "Tổng chiết khấu";
        public static String CONTENT00278 = "Tổng phải thu";
    }
}
