using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainPrj.Model
{
    public enum RoleType
    {
        ROLE_MANAGER = 1,
        ROLE_ADMIN,
        ROLE_SALE,				            // Nhân Viên Kinh Doanh
        ROLE_CUSTOMER,
        ROLE_AGENT,
        ROLE_MEMBER,
        ROLE_EMPLOYEE_MAINTAIN,				// NV Phục Vụ Khách Hàng 
        ROLE_CHECK_MAINTAIN,				// NV Test Bảo Trì
        ROLE_ACCOUNTING_AGENT,				// NV Kế Toán Bán Hàng
        ROLE_ACCOUNTING_AGENT_PRIMARY,		// NV Kế Toán Đại Lý
        ROLE_ACCOUNTING_ZONE,				// NV Kế Toán Khu Vực
        ROLE_MONITORING,				    // NV Giám Sát
        ROLE_MONITORING_MAINTAIN,
        ROLE_MONITORING_MARKET_DEVELOPMENT,	// Mar0216 Chuyên Viên CCS <- Giám Sát PTTT
        ROLE_EMPLOYEE_MARKET_DEVELOPMENT,	// NV PTTT
        ROLE_MONITORING_STORE_CARD,			// Quản Lý Kho
        ROLE_DIEU_PHOI,			            // Điều Phối
        ROLE_SCHEDULE_CAR,				    // Điều Xe
        ROLE_DIRECTOR,				        // Giám Đốc
        ROLE_SUB_USER_AGENT,			    // User Đại Lý
        ROLE_DRIVER,				        // Lái Xe
        ROLE_ACCOUNT_RECEIVABLE,		    // Kế Toán Công Nợ
        ROLE_HEAD_GAS_BO,				    // Trưởng Phòng KD Gas Bò
        ROLE_HEAD_GAS_MOI,				    // Trưởng Phòng KD Gas mối
        ROLE_DIRECTOR_BUSSINESS,		    // Giám Đốc Kinh Doanh
        ROLE_RECEPTION,				        // lễ tân
        ROLE_CHIEF_ACCOUNTANT,			    // Kế Toán Trưởng
        ROLE_CHIEF_MONITOR,				    // Tổng giám sát
        ROLE_MONITOR_AGENT,				    // giám sát đại lý
        ROLE_SECRETARY_OF_THE_MEETING,	    // THƯ KÝ CUỘC HỌP
        ROLE_HEAD_OF_LEGAL,				    // Trưởng Phòng Pháp Lý
        ROLE_EMPLOYEE_OF_LEGAL,			    // Nhân Viên Pháp Lý
        ROLE_ACCOUNTING,				    // Nhân Viên Kế Toán
        ROLE_DEBT_COLLECTION,			    // Nhân Viên Thu Nợ
        ROLE_HEAD_TECHNICAL,			    // Trưởng Phòng Kỹ Thuật
        ROLE_HEAD_OF_MAINTAIN,			    // Tổ Trưởng Tổ Bảo Trì
        ROLE_E_MAINTAIN,				    // NV Bảo Trì
        ROLE_SECURITY_SYSTEM,			    // Security System - Setting cho hệ thống
        ROLE_BUSINESS_PROJECT,			    // NV Kinh Doanh Dự Án
        ROLE_HEAD_OF_BUSINESS,			    // Trưởng Phòng Kinh Doanh Dec 26, 2014
        ROLE_WORKER,				        // Công nhân Dec 26, 2014
        ROLE_SECURITY,				        // Bảo Vệ Dec 26, 2014
        ROLE_MANAGING_DIRECTOR,				// Quản Đốc Dec 29, 2014
        ROLE_CRAFT_WAREHOUSE,				// Thủ Kho Dec 29, 2014
        ROLE_HEAD_GAS_FAMILY,				// Trưởng Phòng Gas Gia Đình Jan 20, 2015
        ROLE_TEST_CALL_CENTER,				// NV test tổng đài Sep 03, 2015
        ROLE_CHIET_NAP,				        // NV chiết nạp Sep 03, 2015
        ROLE_PHU_XE,				        // NV Phụ Xe Sep 03, 2015
        ROLE_SUB_DIRECTOR,			        // Phó Giám Đốc Chi Nhánh SEP 11, 2015
        ROLE_ITEMS,				            // Vật Tư SEP 11, 2015
        ROLE_CASHIER,				        // Thủ Quỹ SEP 11, 2015
        ROLE_MECHANIC,				        // Cơ Khí SEP 11, 2015
        ROLE_TECHNICAL,				        // NV Kỹ Thuật SEP 19, 2015
        ROLE_AUDIT,				            // NV AUDIT dec 15, 2015
        ROLE_SALE_ADMIN,			        // NV QUAN LY kh MAR 12, 2016
        ROLE_IT,				            // Phòng Công Nghệ Thông Tin Apr 04, 2016
        ROLE_IT_EMPLOYEE,			        // NV Công Nghệ Thông Tin Apr 04, 2016
        ROLE_BRANCH_DIRECTOR,		        // Giám Đốc Chi Nhánh May 08, 2016
        ROLE_CLEANER,				        // NV Tạp Vụ May 08, 2016
        ROLE_MANAGER_DRIVER,				// Quản Lý Đội Xe May 17, 2016,
        ROLETYPE_NUM
    }
}
