﻿namespace BTC_ENTERPRISE.Model
{
    public class WarehouseKitting
    {
        public class manufacturing_order
        {
            public string? mo_id { get; set; }
            public string? pcn_number { get; set; }
            public string? description { get; set; }
            public string? location { get; set; }
            public string? bom_item { get; set; }
            public string? bom_revision_number { get; set; }
            public string? order_quantity { get; set; }
            public string? order_date { get; set; }
            public string? kit_date { get; set; }
            public string? start_date { get; set; }
            public string? end_date { get; set; }
            public bool is_build_america_buy_america { get; set; }
            public List<item>? kit_list_items { get; set; }
        }
        public class item
        {
            public string? mo_id { get; set; }
            public string? item_number { get; set; }
            public string? group { get; set; }
            public string? ipn { get; set; }
            public string? description { get; set; }
            public string? type { get; set; }
            public string? manufacturing { get; set; }
            public string? manufacturing_product_code { get; set; }
            public string? source_location { get; set; }

            public decimal? stock { get; set; }
            public decimal? unit_quantity { get; set; }
            public decimal? mo_quantity { get; set; }
            public decimal? wip_quantity { get; set; }
            public decimal? pick_quantity { get; set; }
            public decimal? short_quantity { get; set; }

            public string? unit { get; set; }
            public string? invoice_number { get; set; }
            public string? kitted { get; set; }
            public string? individual_kitting { get; set; }
            public string? track { get; set; }
            public string? rack { get; set; }
            public string? comment { get; set; }
            public bool Selected { get; internal set; }
        }
        public class Link
        {
            public string? url { get; set; }
            public string? label { get; set; }
            public bool active { get; set; }
        }
        public class GetData
        {
            public object? current_page { get; set; }
            public List<manufacturing_order_items>? data { get; set; }
            public string? first_page_url { get; set; }
            public object? from { get; set; }
            public int last_page { get; set; }
            public string? last_page_url { get; set; }
            public List<Link>? links { get; set; }
            public object? next_page_url { get; set; }
            public string? path { get; set; }
            public int per_page { get; set; }
            public object? prev_page_url { get; set; }
            public object? to { get; set; }
            public int total { get; set; }
        }
        public class manufacturing_order_getdata
        {
            public int id { get; set; }
            public string? mo_id { get; set; }
            public string? pcn_number { get; set; }
            public string? description { get; set; }
            public string? location { get; set; }
            public string? bom_item { get; set; }
            public string? bom_revision_number { get; set; }
            public string? order_quantity { get; set; }
            public string? order_date { get; set; }
            public string? created_at { get; set; }
            public string? updated_at { get; set; }
            public List<manufacturing_order_items>? manufacturing_order_items { get; set; }
        }
        public class manufacturing_order_items
        {
            public int id { get; set; }
            public int kit_list_item_status_id { get; set; }
            public string? mo_id { get; set; }
            public string? item_number { get; set; }
            public string? group { get; set; }
            public string? ipn { get; set; }
            public string? description { get; set; }
            public string? type { get; set; }
            public string? manufacturing { get; set; }
            public string? manufacturing_product_code { get; set; }
            public string? source_location { get; set; }
            public string? stock { get; set; }
            public string? unit_quantity { get; set; }
            public string? mo_quantity { get; set; }
            public string? wip_quantity { get; set; }
            public string? pick_quantity { get; set; }
            public string? short_quantity { get; set; }
            public string? unit { get; set; }
            public string? invoice_number { get; set; }
            public string? kitted { get; set; }
            public string? individual_kitting { get; set; }
            public string? track { get; set; }
            public string? rack { get; set; }
            public string? comment { get; set; }
            public string? created_at { get; set; }
            public string? updated_at { get; set; }
            public List<serials>? serial { get; set; }
            public status? status { get; set; }
            public bool Selected { get; internal set; }
            public string item_status { get; set; }
            // public string[] history { get; set; }
        }
        public class serials
        {
            public int id { get; set; }
            public int kit_list_item_id { get; set; }
            public int kit_list_item_serial_number_status_id { get; set; }
            public string? kit_list_part_serial_number { get; set; }
            public int is_scan { get; set; }
            public string? created_at { get; set; }
            public string? updated_at { get; set; }
            public status? status { get; set; }

        }
        public class status
        {
            public int id { get; set; }
            public string? name { get; set; }
            public string? description { get; set; }
            public string? color { get; set; }
            public string? created_at { get; set; }
            public string? updated_at { get; set; }
        }
        public class error_logs
        {
            public error? errors { get; set; }
            public string? message { get; set; }
        }
        public class error
        {
            public string[]? mo_id { get; set; }
        }
        public class Root
        {
            public int kit_list_item_id { get; set; }
            public int short_quantity { get; set; }
            public int kit_quantity { get; set; }
            public string? comment { get; set; }
            public int kit_list_item_status_id {get; set; }
            public List<serial_number>? kit_list_item_serial { get; set; }
        }

        public class serial_number
        {
            public int kit_list_item_id { get; set; }
            public string? kit_list_part_serial_number { get; set; }
        }
        public class kitted_quantity
        {
            public int id { get; set; }
            public string? kitted { get; set; }
            public string? comment { get; set; }
            public int kit_list_item_status_id { get; set; }
        }
        public class add_serial_number
        {
            public List<serial_number>? kit_list_item_serial { get; set; }
        }
        public class update_kitting_quantity
        {
            public int kit_list_id { get; set; }
            public int kit_list_status_id { get; set; }
           // public List<kitted_quantity> kit_list_items { get; set; }
        }
        public class result
        {
            public int kit_list_type_id { get; set; }
            public int kit_list_status_id { get; set; }
            public string? mo_id { get; set; }
            public string? pcn_number { get; set; }
            public string? description { get; set; }
            public string? location { get; set; }
            public string? bom_item { get; set; }
            public string? bom_revision_number { get; set; }
            public string? order_quantity { get; set; }
            public string? order_date { get; set; }
            public string? updated_at { get; set; }
            public string? created_at { get; set; }
            public int id { get; set; }
        }
        public class get_serial
        {
            public int id { get; set; }
            public int kit_list_item_id { get; set; }
            public int kit_list_item_serial_number_status_id { get; set; }
            public string? kit_list_part_serial_number { get; set; }
            public int is_scan { get; set; }
            public string? created_at { get; set; }
            public string? updated_at { get; set; }
            public kit_list_item? kit_list_item { get; set; }
        }
        public class kit_list_item
        {
            public int id { get; set; }
            public string? ipn { get; set; }
            public string? mo_id { get; set; }
        }
        public class scan_serial
        {
            public List<serial_details>? kit_list_item_serial { get; set; }
        }
        public class serial_details
        {
            public int id { get; set; }
            public int is_scan { get; set; }
        }

        public class ApiError
        {
            public string? message { get; set; }
            public Dictionary<string, List<string>>? errors { get; set; }
            public int id { get; set; }
            public int kit_list_status_id { get; set; }
        }


    }
}
