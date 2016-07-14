#include <cpprest/http_client.h>
#include <cpprest/filestream.h>
#include <cpprest/json.h>

#include <iostream>

using namespace utility;
using namespace web;
using namespace web::http;
using namespace web::http::client;
using namespace concurrency::streams;

using namespace std;

void print_search_results(json::value const & value)
{
	if (!value.is_null())
	{
		//auto response = value.at(L"data");
		//auto results = response[L"movies"];

		// iteration is supported not directly on json::value but on 
		// json::object and json::array. Use json::value::as_object() and json::value::as_array().
		std::wcout << value.as_array().at(0) << std::endl;
		for (auto const & o : value.as_array())
		{
			auto id = o.at(L"id");
			auto name = o.at(L"name");
			auto username = o.at(L"username");
			auto email = o.at(L"email");
			auto address = o.at(L"address");
			auto street = address.at(L"street");
			
			std::wcout << id << std::endl << name << std::endl << username << std::endl << email << std::endl << street << std::endl << std::endl;
		}
	}
}

void search_and_print(std::wstring const & searchTerm, int resultsCount)
{
	/*http_client client(U("http://www.myapifilms.com/imdb/idIMDB"));

	// build the query parameters
	auto query = uri_builder()
		.append_query(L"title", searchTerm)
		.append_query(L"token", L"d6650b7b-79df-436d-a11e-3ac3fa0e57e3")
		.append_query(L"format", "json")
		.append_query(L"limit", resultsCount)
		.to_string();
		*/
	
	http_client client(U("http://jsonplaceholder.typicode.com/users"));

		// build the query parameters
		auto query = uri_builder()
		.to_string();
		
	client
		// send the HTTP GET request asynchronous
		.request(methods::GET, query)
		// continue when the response is available
		.then([](http_response response) -> pplx::task<json::value>
	{
		// if the status is OK extract the body of the response into a JSON value
		// works only when the content type is application\json
		if (response.status_code() == status_codes::OK)
		{
			return response.extract_json();
		}

		// return an empty JSON value
		return pplx::task_from_result(json::value());
	})
		// continue when the JSON value is available
		.then([](pplx::task<json::value> previousTask)
	{
		// get the JSON value from the task and display content from it
		try
		{
			json::value const & v = previousTask.get();
			print_search_results(v);
		}
		catch (http_exception const & e)
		{
			std::wcout << e.what() << std::endl;
		}
	})
		.wait();
}
int main(int argc, char *args[])
{
	search_and_print(L"avatar", 100);

	string input;
	getline(cin, input);

	return 0;
}