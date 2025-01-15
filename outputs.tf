output "app_ips" {
  value = azurerm_linux_web_app.alwa.outbound_ip_address_list
}
output "app_url" {
  value = azurerm_linux_web_app.alwa.default_hostname
}